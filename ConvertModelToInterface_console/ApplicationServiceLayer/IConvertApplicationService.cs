using System;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.ApplicationServiceLayer
{
    public interface IConvertApplicationService
    {

        T Convert<T>(T FromObj) where T:IModel;

    }
}
