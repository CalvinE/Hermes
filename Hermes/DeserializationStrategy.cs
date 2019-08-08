using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core
{
    public class DeserializationStrategy
    {
        private static DefaultContractResolver _defaultContractResolver;

        /// <summary>
        /// 
        /// </summary>
        public static DefaultContractResolver DefaultContractResolver
        {
            get
            {
                if (_defaultContractResolver == null)
                {
                    _defaultContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy
                        {
                            OverrideSpecifiedNames = false
                        }
                    };
                }
                return _defaultContractResolver;
            }
        }
    }
}
