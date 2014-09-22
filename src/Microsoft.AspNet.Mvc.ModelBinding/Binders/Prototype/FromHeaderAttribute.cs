// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace Microsoft.AspNet.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromHeaderAttribute : Attribute, IBinderMarker
    {
        public FromHeaderAttribute(string key)
        {
            HeaderKey = key;
        }

        public string HeaderKey { get; private set; }

        public bool ForceBind { get; set; }
    }
}
