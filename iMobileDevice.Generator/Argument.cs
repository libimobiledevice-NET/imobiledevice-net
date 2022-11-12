﻿// <copyright file="Argument.cs" company="Quamotion">
// Copyright (c) Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Generator
{
    using System;
    using System.CodeDom;
    using System.Runtime.InteropServices;
    using System.Collections.ObjectModel;
    using ClangSharp.Interop;

    internal static class Argument
    {
        public static CodeAttributeDeclaration MarshalAsUtf8String()
        {
            return MarshalAsDeclaration(UnmanagedType.CustomMarshaler, new CodeTypeReference("NativeStringMarshaler"));
        }

        public static CodeAttributeDeclaration MarshalAsUtf8StringArray()
        {
            return MarshalAsDeclaration(UnmanagedType.CustomMarshaler, new CodeTypeReference("NativeStringArrayMarshaler"));
        }

        public static CodeAttributeDeclaration MarshalAsFixedLengthStringDeclaration(int size)
        {
            var value = new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(MarshalAsAttribute)),
                new CodeAttributeArgument(
                    new CodePropertyReferenceExpression(
                        new CodeTypeReferenceExpression(typeof(UnmanagedType)),
                        UnmanagedType.ByValTStr.ToString())));

            value.Arguments.Add(
                new CodeAttributeArgument(
                    "SizeConst",
                    new CodePrimitiveExpression(size)));

            return value;
        }

        public static CodeAttributeDeclaration MarshalAsFixedLengthArrayDeclaration(int size)
        {
            var value = new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(MarshalAsAttribute)),
                new CodeAttributeArgument(
                    new CodePropertyReferenceExpression(
                        new CodeTypeReferenceExpression(typeof(UnmanagedType)),
                        UnmanagedType.ByValArray.ToString())));

            value.Arguments.Add(
                new CodeAttributeArgument(
                    "SizeConst",
                    new CodePrimitiveExpression(size)));

            return value;
        }

        public static CodeAttributeDeclaration MarshalAsDeclaration(UnmanagedType type, CodeTypeReference customMarshaler = null)
        {
            var value = new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(MarshalAsAttribute)),
                new CodeAttributeArgument(
                    new CodePropertyReferenceExpression(
                        new CodeTypeReferenceExpression(typeof(UnmanagedType)),
                        type.ToString())));

            if (type == UnmanagedType.CustomMarshaler)
            {
                value.Arguments.Add(
                    new CodeAttributeArgument(
                        "MarshalTypeRef",
                        new CodeTypeOfExpression(
                            customMarshaler)));
            }

            return value;
        }

        public static CodeParameterDeclarationExpression GenerateArgument(this ModuleGenerator generator, CXType functionType, CXCursor paramCXCursor, uint index, FunctionType functionKind)
        {
            var numArgTypes = functionType.NumArgTypes;
            var type = functionType.GetArgType(index);
            var cursorType = paramCXCursor.Type;

            var name = paramCXCursor.Spelling.CString;
            if (string.IsNullOrEmpty(name))
            {
                name = "param" + index;
            }

            name = NameConversions.ToClrName(name, NameConversion.Parameter);

            CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression();
            parameter.Name = name;

            bool isPointer = false;

            if (functionKind != FunctionType.Free
                && functionKind != FunctionType.Delegate
                && type.IsDoubleCharPointer()
                && !name.Contains("data")
                && name != "appids")
            {
                parameter.Type = new CodeTypeReference(typeof(string));
                parameter.Direction = FieldDirection.Out;

                parameter.CustomAttributes.Add(MarshalAsUtf8String());
            }
            else if (functionKind != FunctionType.Delegate && type.IsTripleCharPointer() && generator.StringArrayMarshalerType != null)
            {
                parameter.Type = new CodeTypeReference(typeof(ReadOnlyCollection<string>));
                parameter.Direction = FieldDirection.Out;

                parameter.CustomAttributes.Add(MarshalAsDeclaration(UnmanagedType.CustomMarshaler, new CodeTypeReference(generator.StringArrayMarshalerType.Name)));
            }
            else if (functionKind != FunctionType.Delegate && (type.IsArrayOfCharPointers() || type.IsDoublePtrToConstChar()))
            {
                parameter.Type = new CodeTypeReference(typeof(ReadOnlyCollection<string>));
                parameter.Direction = FieldDirection.In;

                parameter.CustomAttributes.Add(MarshalAsUtf8StringArray());
            }
            else
            {
                switch (type.kind)
                {
                    case CXTypeKind.CXType_Pointer:
                        var pointee = type.PointeeType;
                        switch (pointee.kind)
                        {
                            case CXTypeKind.CXType_Pointer:
                                parameter.Type = new CodeTypeReference(typeof(IntPtr));
                                isPointer = true;
                                break;

                            case CXTypeKind.CXType_FunctionProto:
                                parameter.Type = new CodeTypeReference(cursorType.ToClrType());
                                break;

                            case CXTypeKind.CXType_Void:
                                parameter.Type = new CodeTypeReference(typeof(IntPtr));
                                break;

                            case CXTypeKind.CXType_Char_S:
                                // In some of the read/write functions, const char is also used to represent data -- in that
                                // case, it maps to a byte[] array or just an IntPtr.
                                if (functionKind != FunctionType.PInvoke && type.IsPtrToConstChar())
                                {
                                    if (!name.Contains("data") && name != "signature")
                                    {
                                        parameter.Type = new CodeTypeReference(typeof(string));
                                        parameter.CustomAttributes.Add(MarshalAsDeclaration(UnmanagedType.LPStr));
                                    }
                                    else
                                    {
                                        parameter.Type = new CodeTypeReference(typeof(byte[]));
                                    }
                                }
                                else if (functionKind != FunctionType.PInvoke && functionKind != FunctionType.Delegate && type.IsPtrToChar() && name.Contains("data"))
                                {
                                    parameter.Type = new CodeTypeReference(typeof(byte[]));
                                }
                                else
                                {
                                    // if it's not a const, it's best to go with IntPtr
                                    parameter.Type = new CodeTypeReference(typeof(IntPtr));
                                }

                                break;

                            case CXTypeKind.CXType_WChar:
                                if (type.IsPtrToConstChar())
                                {
                                    parameter.Type = new CodeTypeReference(typeof(string));
                                    parameter.CustomAttributes.Add(MarshalAsDeclaration(UnmanagedType.LPWStr));
                                }
                                else
                                {
                                    parameter.Type = new CodeTypeReference(typeof(IntPtr));
                                }

                                break;

                            case CXTypeKind.CXType_Record:
                                if (functionKind != FunctionType.Delegate)
                                {
                                    var recordTypeCXCursor = pointee.Declaration;
                                    var recordType = recordTypeCXCursor.Type;

                                    // Get the CLR name for the record
                                    var clrName = generator.NameMapping[recordType.Spelling.CString.ToString()];
                                    parameter.Type = new CodeTypeReference(clrName);
                                    isPointer = true;
                                }
                                else
                                {
                                    // if it's not a const, it's best to go with IntPtr
                                    parameter.Type = new CodeTypeReference(typeof(IntPtr));
                                    isPointer = true;
                                }

                                break;

                            default:
                                parameter.Type = pointee.ToCodeTypeReference(paramCXCursor, generator);
                                isPointer = true;
                                break;
                        }

                        break;

                    default:
                        if (generator.NameMapping.ContainsKey(type.Spelling.CString.ToString()))
                        {
                            if (functionKind != FunctionType.Delegate)
                            {
                                parameter.Type = type.ToCodeTypeReference(paramCXCursor, generator);
                            }
                            else
                            {
                                parameter.Type = new CodeTypeReference(typeof(IntPtr));
                            }
                        }
                        else
                        {
                            parameter.Type = type.ToCodeTypeReference(paramCXCursor, generator);
                        }

                        break;
                }
            }

            if (functionKind == FunctionType.Delegate && parameter.Type.BaseType.EndsWith("Handle"))
            {
                // Use a custom marshaler
                parameter.CustomAttributes.Add(
                    MarshalAsDeclaration(
                        UnmanagedType.CustomMarshaler,
                        new CodeTypeReference(parameter.Type.BaseType + "DelegateMarshaler")));
            }

            if (isPointer)
            {
                switch (functionKind)
                {
                    case FunctionType.None:
                    case FunctionType.Delegate:
                        if (parameter.Type.BaseType.EndsWith("Handle"))
                        {
                            // Handles are always out parameters
                            parameter.Direction = FieldDirection.Out;
                        }
                        else
                        {
                            // For IntPtrs, we don't know - so we play on the safe side.
                            parameter.Direction = FieldDirection.Ref;
                        }

                        break;

                    case FunctionType.New:
                    case FunctionType.PInvoke:
                        parameter.Direction = FieldDirection.Out;
                        break;

                    case FunctionType.Free:
                        parameter.Direction = FieldDirection.In;
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            return parameter;
        }
    }
}
