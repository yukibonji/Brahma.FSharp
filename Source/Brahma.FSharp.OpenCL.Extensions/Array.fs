﻿// Copyright (c) 2013 Semyon Grigorev <rsdpisuy@gmail.com>
// All rights reserved.
// 
// The contents of this file are made available under the terms of the
// Eclipse Public License v1.0 (the "License") which accompanies this
// distribution, and is available at the following URL:
// http://www.opensource.org/licenses/eclipse-1.0.php
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either expressed or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// By using this software in any fashion, you are agreeing to be bound by the
// terms of the License.

[<AutoOpen>]
module Brahma.FSharp.OpenCL.Extensions

open System.Runtime.InteropServices
open OpenCL.Net
open Brahma.OpenCL

type ``[]``<'t> with
    member this.ToHost(kernel:ICLKernel) =
        new Commands.ReadBuffer<'t>(kernel.AutoconfiguredBuffers.[this], Marshal.SizeOf(typeof<'t>),true,0,this.Length,this)
    member this.ToHost(kernel:ICLKernel, hostArray:array<'t>) =
        new Commands.ReadBuffer<'t>(kernel.AutoconfiguredBuffers.[this], Marshal.SizeOf(typeof<'t>),true,0,hostArray.Length,hostArray)