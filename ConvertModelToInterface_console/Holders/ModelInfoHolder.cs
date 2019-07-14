using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.Holders
{
    public class ModelInfoHolder
    {
        private IModel FromModel;
        private IModel ToModel;
        private IEnumerable<IModel> FromModelCollection;
        private IEnumerable<IModel> ToModelCollection;
        private IEnumerable<MetaDataModel> ModelMetaData;

        public ModelInfoHolder(IModel fromModel, IEnumerable<MetaDataModel> modelMetaData)
        {
            this.FromModel = fromModel;
            this.ModelMetaData = modelMetaData;
        }

        public ModelInfoHolder(IEnumerable<IModel> fromModelCollection, IEnumerable<MetaDataModel> modelMetaData)
        {
            this.FromModelCollection = fromModelCollection;
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

        public IEnumerable<IModel> GetFromModelCollection()
        {
            return this.FromModelCollection;
        }
        public IEnumerable<IModel> GetToModelCollection()
        {
            return this.ToModelCollection;
        }

        public void SetToModel(IModel toModel)
        {
            this.ToModel = toModel;
        }

        public void SetToModel(IEnumerable<IModel> toModel)
        {
            this.ToModelCollection = toModel;
        }

        public IEnumerable<Object> GetModelMetaData()
        {
            return this.ModelMetaData;
        }
    }
}
