//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Edm.Library
{
    /// <summary>
    /// Represents a definition of an EDM entity reference type.
    /// </summary>
    public class EdmEntityReferenceType : EdmType, IEdmEntityReferenceType
    {
        private readonly IEdmEntityType entityType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmEntityReferenceType"/> class.
        /// </summary>
        /// <param name="entityType">The entity referred to by this entity reference.</param>
        public EdmEntityReferenceType(IEdmEntityType entityType)
        {
            EdmUtil.CheckArgumentNull(entityType, "entityType");
            this.entityType = entityType;
        }

        /// <summary>
        /// Gets the kind of this type.
        /// </summary>
        public override EdmTypeKind TypeKind
        {
            get { return EdmTypeKind.EntityReference; }
        }

        /// <summary>
        /// Gets the entity type pointed to by this entity reference.
        /// </summary>
        public IEdmEntityType EntityType
        {
            get { return this.entityType; }
        }
    }
}
