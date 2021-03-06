namespace Zing.Mvc
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Define a class that is used to store the selectable element setting.
    /// </summary>
    public class ModelMetadataItemSelectableElementSetting : IModelMetadataAdditionalSetting
    {
        /// <summary>
        /// Gets or sets the view data key.
        /// </summary>
        /// <value>The view data key.</value>
        public string ViewDataKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        /// <value>The option label.</value>
        public Func<string> OptionLabel
        {
            get;
            set;
        }
    }
}