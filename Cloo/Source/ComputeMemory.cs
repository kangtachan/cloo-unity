﻿#region License

/*

Copyright (c) 2009 Fatjon Sakiqi

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace Cloo
{
    using System;
    using OpenTK.Compute.CL10;

    public abstract class ComputeMemory: ComputeResource
    {
        #region Fields
        
        protected long byteCount;
        private readonly ComputeContext context;
        private readonly ComputeMemoryFlags ComputeMemoryFlags;        

        #endregion

        #region Properties

        public ComputeContext Context
        {
            get
            {
                return context;
            }
        }

        public ComputeMemoryFlags Flags
        {
            get
            {
                return ComputeMemoryFlags;
            }
        }

        public long ByteSize
        {
            get
            {
                return byteCount;
            }
        }

        #endregion

        #region Constructors

        protected ComputeMemory( ComputeContext context, ComputeMemoryFlags flags )
        {
            this.context = context;
            this.ComputeMemoryFlags = flags;
        }

        #endregion

        #region Protected methods

        protected override void Dispose( bool manual )
        {            
            if( Handle != IntPtr.Zero )
            {
                CL.ReleaseMemObject( Handle );
                Handle = IntPtr.Zero;
            }
        }

        #endregion
    }
}
