using System;
namespace ConvertModelToInterface_console.Context
{
    /// <summary>
    /// Name in infra attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class NameInInfraAttribute : Attribute
    {
        /// <summary>
        /// The name in infra
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:ConvertModelToInterface_console.Context.NameInInfraAttribute"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public NameInInfraAttribute(string name) { this.Name = name; }
    }
}
