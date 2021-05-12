using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sentral.API.Model.Common
{
    public interface IToUpdatable<T>
    {
        T ToUpdatable();
    }
}
