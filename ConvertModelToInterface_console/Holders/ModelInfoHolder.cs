using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.Holders
{
    public class ModelInfoHolder
    {
        private IModel FromModel;
        private IModel ToModel;
        private IEnumerable<Object> ModelMetaData;

        public ModelInfoHolder(IModel fromModel, IEnumerable<Object> modelMetaData)
        {
            this.FromModel = fromModel;
            this.ModelMetaData = modelMetaData;
        }

        public IModel GetFromModel()
        {
            return this.FromModel;
        }
        public IModel GetToModel()
        {
            return this.ToModel;
        }

        public void SetToModel(IModel toModel)
        {
            this.ToModel = toModel;
        }

        public IEnumerable<Object> GetModelMetaData()
        {
            return this.ModelMetaData;
        }
    }
}
