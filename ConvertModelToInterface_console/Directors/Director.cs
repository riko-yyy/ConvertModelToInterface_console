using System;
using ConvertModelToInterface_console.Builders;
using ConvertModelToInterface_console.Holders;

namespace ConvertModelToInterface_console.Directors
{
    public class Director
    {
        private readonly IBuilder Builder;
        private ModelInfoHolder ModelInfoHolder;

        public Director(IBuilder builder, ModelInfoHolder modelInfoHolder)
        {
            builder.SetHolder(modelInfoHolder);
            this.Builder = builder;
            this.ModelInfoHolder = modelInfoHolder;
        }

        public void ConvertModel()
        {
            Builder.CreateToModel();
        }
    }
}
