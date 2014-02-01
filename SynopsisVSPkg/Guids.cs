// Guids.cs
// MUST match guids.h
using System;

namespace Synopsis.SynopsisVSPkg
{
    static class GuidList
    {
        public const string guidSynopsisVSPkgPkgString = "3f4a3bed-7173-4756-bcc1-61840ab141d7";
        public const string guidSynopsisVSPkgCmdSetString = "7381cdc5-d15f-43d7-83e5-a3a108655346";
        public const string guidToolWindowPersistanceString = "3366386a-a827-493b-87dc-74197275d912";

        public static readonly Guid guidSynopsisVSPkgCmdSet = new Guid(guidSynopsisVSPkgCmdSetString);
    };
}