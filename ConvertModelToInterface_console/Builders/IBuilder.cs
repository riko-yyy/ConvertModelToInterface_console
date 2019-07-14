using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.Builders
{
    public interface IBuilder
    {
        void SetHolder(ModelInfoHolder modelInfoHolder);
        void CreateToModel();
        T ConvertFromModel<T>(T fromObj) where T : IModel;
    }
}
