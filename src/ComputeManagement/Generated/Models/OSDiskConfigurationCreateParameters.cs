// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;

namespace Microsoft.WindowsAzure.Management.Compute.Models
{
    /// <summary>
    /// The OS disk configuration.
    /// </summary>
    public partial class OSDiskConfigurationCreateParameters
    {
        private string _hostCaching;
        
        /// <summary>
        /// Optional. Gets or sets the platform caching behavior of the
        /// operating system disk blob for read/write efficiency.
        /// </summary>
        public string HostCaching
        {
            get { return this._hostCaching; }
            set { this._hostCaching = value; }
        }
        
        private Uri _mediaLink;
        
        /// <summary>
        /// Required. Gets or sets the location of the blob in Windows Azure
        /// storage. The blob location belongs to a storage account in the
        /// subscription specified by the <subscription-id> value in the
        /// operation call.
        /// </summary>
        public Uri MediaLink
        {
            get { return this._mediaLink; }
            set { this._mediaLink = value; }
        }
        
        private string _os;
        
        /// <summary>
        /// Required. Gets or sets the operating system in the image.
        /// </summary>
        public string OS
        {
            get { return this._os; }
            set { this._os = value; }
        }
        
        private string _oSState;
        
        /// <summary>
        /// Required. Gets or sets the state of the operating system in the
        /// image.
        /// </summary>
        public string OSState
        {
            get { return this._oSState; }
            set { this._oSState = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// OSDiskConfigurationCreateParameters class.
        /// </summary>
        public OSDiskConfigurationCreateParameters()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// OSDiskConfigurationCreateParameters class with required arguments.
        /// </summary>
        public OSDiskConfigurationCreateParameters(string oSState, string os, Uri mediaLink)
            : this()
        {
            if (oSState == null)
            {
                throw new ArgumentNullException("oSState");
            }
            if (os == null)
            {
                throw new ArgumentNullException("os");
            }
            if (mediaLink == null)
            {
                throw new ArgumentNullException("mediaLink");
            }
            this.OSState = oSState;
            this.OS = os;
            this.MediaLink = mediaLink;
        }
    }
}
