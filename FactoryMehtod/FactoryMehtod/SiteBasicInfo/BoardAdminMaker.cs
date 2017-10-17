using FactoryMehtodLib.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("FactoryMethodLib.Test")]

namespace FactoryMehtodLib.SiteBasicInfo
{
    public class BoardAdminMaker : SiteBasicInfoMaker
    {
        public BoardAdminMaker(Joiner createdJoiner) : base(createdJoiner)
        {
        }

        public void Do()
        {
            throw new NotImplementedException();
        }
    }
}
