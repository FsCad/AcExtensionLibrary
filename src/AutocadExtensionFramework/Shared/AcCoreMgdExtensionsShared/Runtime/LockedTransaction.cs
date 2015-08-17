﻿using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace Autodesk.AutoCAD.Runtime
{
   public class LockedTransaction : Transaction
    {
       DocumentLock docLock;
       public LockedTransaction(Transaction trx, DocumentLock docLock)
           : base(trx.UnmanagedObject, trx.AutoDelete)
       {
           Interop.DetachUnmanagedObject(trx);
           GC.SuppressFinalize(trx);
           this.docLock = docLock;
           
       }

       protected override void Dispose(bool A_1)
       {

           base.Dispose(A_1);
           if (A_1)
           {
               docLock.Dispose();
           }
       }
    }

  
}
