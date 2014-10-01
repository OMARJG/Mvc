﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace Microsoft.AspNet.Mvc.ReflectedModelBuilder
{
    public class ReflectedParameterModel
    {
        public ReflectedParameterModel(ParameterInfo parameterInfo)
        {
            ParameterInfo = parameterInfo;

            // CoreCLR returns IEnumerable<Attribute> from GetCustomAttributes - the OfType<object>
            // is needed to so that the result of ToList() is List<object>
            Attributes = parameterInfo.GetCustomAttributes(inherit: true).OfType<object>().ToList();

            ParameterName = parameterInfo.Name;
            IsOptional = ParameterInfo.HasDefaultValue;

            var binderMarker  = Attributes.OfType<IBinderMarker>().FirstOrDefault();
            var binderFactory = Attributes.OfType<IBinderFactory>().FirstOrDefault();

            BinderMetadata = binderMarker;
            if (binderMarker == null)
            {
                BinderMetadata = binderFactory;
            }
        }

        public List<object> Attributes { get; private set; }

        public object BinderMetadata { get; set; }

        public bool IsOptional { get; set; }

        public ParameterInfo ParameterInfo { get; private set; }

        public string ParameterName { get; set; }
    }
}