//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

using System.Collections.Generic;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Values;

namespace Microsoft.OData.Edm.Library
{
    /// <summary>
    /// Represents the definition of an Edm enumeration type.
    /// </summary>
    public class EdmEnumType : EdmType, IEdmEnumType
    {
        private readonly IEdmPrimitiveType underlyingType;
        private readonly string namespaceName;
        private readonly string name;
        private readonly bool isFlags;
        private readonly List<IEdmEnumMember> members = new List<IEdmEnumMember>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmEnumType"/> class with <see cref="EdmPrimitiveTypeKind.Int32"/> underlying type.
        /// </summary>
        /// <param name="namespaceName">Namespace this enumeration type belongs to.</param>
        /// <param name="name">Name of this enumeration type.</param>
        public EdmEnumType(string namespaceName, string name)
            : this(namespaceName, name, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmEnumType"/> class with <see cref="EdmPrimitiveTypeKind.Int32"/> underlying type.
        /// </summary>
        /// <param name="namespaceName">Namespace this enumeration type belongs to.</param>
        /// <param name="name">Name of this enumeration type.</param>
        /// <param name="isFlags">A value indicating whether the enumeration type can be treated as a bit field.</param>
        public EdmEnumType(string namespaceName, string name, bool isFlags)
            : this(namespaceName, name, EdmPrimitiveTypeKind.Int32, isFlags)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmEnumType"/> class with <see cref="EdmPrimitiveTypeKind.Int32"/> underlying type.
        /// </summary>
        /// <param name="namespaceName">Namespace this enumeration type belongs to.</param>
        /// <param name="name">Name of this enumeration type.</param>
        /// <param name="underlyingType">The underlying type of this enumeration type.</param>
        /// <param name="isFlags">A value indicating whether the enumeration type can be treated as a bit field.</param>
        public EdmEnumType(string namespaceName, string name, EdmPrimitiveTypeKind underlyingType, bool isFlags)
            : this(namespaceName, name, EdmCoreModel.Instance.GetPrimitiveType(underlyingType), isFlags)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmEnumType"/> class.
        /// </summary>
        /// <param name="namespaceName">Namespace this enumeration type belongs to.</param>
        /// <param name="name">Name of this enumeration type.</param>
        /// <param name="underlyingType">The underlying type of this enumeration type.</param>
        /// <param name="isFlags">A value indicating whether the enumeration type can be treated as a bit field.</param>
        public EdmEnumType(string namespaceName, string name, IEdmPrimitiveType underlyingType, bool isFlags)
        {
            EdmUtil.CheckArgumentNull(underlyingType, "underlyingType");
            EdmUtil.CheckArgumentNull(namespaceName, "namespaceName");
            EdmUtil.CheckArgumentNull(name, "name");

            this.underlyingType = underlyingType;
            this.name = name;
            this.namespaceName = namespaceName;
            this.isFlags = isFlags;
        }

        /// <summary>
        /// Gets the kind of this type.
        /// </summary>
        public override EdmTypeKind TypeKind
        {
            get { return EdmTypeKind.Enum; }
        }

        /// <summary>
        /// Gets the kind of this schema element.
        /// </summary>
        public EdmSchemaElementKind SchemaElementKind
        {
            get { return EdmSchemaElementKind.TypeDefinition; }
        }

        /// <summary>
        /// Gets the namespace this schema element belongs to.
        /// </summary>
        public string Namespace
        {
            get { return this.namespaceName; }
        }

        /// <summary>
        /// Gets the name of this enumeration type.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the underlying type of this enumeration type.
        /// </summary>
        public IEdmPrimitiveType UnderlyingType
        {
            get { return this.underlyingType; }
        }

        /// <summary>
        /// Gets the members of this enumeration type.
        /// </summary>
        public virtual IEnumerable<IEdmEnumMember> Members
        {
            get { return this.members; }
        }

        /// <summary>
        /// Gets a value indicating whether the enumeration type can be treated as a bit field.
        /// </summary>
        public bool IsFlags
        {
            get { return this.isFlags; }
        }

        /// <summary>
        /// Adds a new member to this enum type.
        /// </summary>
        /// <param name="member">The member to add.</param>
        public void AddMember(IEdmEnumMember member)
        {
            this.members.Add(member);
        }

        /// <summary>
        /// Creates and adds a new member to this enum type.
        /// </summary>
        /// <param name="name">Name of the member.</param>
        /// <param name="value">Value of the member.</param>
        /// <returns>Created member.</returns>
        public EdmEnumMember AddMember(string name, IEdmPrimitiveValue value)
        {
            EdmEnumMember member = new EdmEnumMember(this, name, value);
            this.AddMember(member);
            return member;
        }
    }
}
