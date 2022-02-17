namespace Rapport.AuxiliaryTools.GenericsAndTemplates
{
    using System;

    public class LazyInitializer<T>
        where T : new()
    {
        private static readonly Lazy<T> currInstanceHolder = new Lazy<T>( () => new T() );

        public static T Instance
        {
            get
            {
                return currInstanceHolder.Value;
            }
        }
    }
}
