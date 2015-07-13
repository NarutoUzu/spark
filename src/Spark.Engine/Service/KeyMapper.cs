﻿/* 
 * Copyright (c) 2014, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.github.com/furore-fhir/spark/master/LICENSE
 */

using Hl7.Fhir.Rest;
using Spark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Service
{
    public class Mapper<TKEY, TVALUE>
    {
        Dictionary<TKEY, TVALUE> mapping = new Dictionary<TKEY, TVALUE>();

        public Mapper() { }

        public void Clear()
        {
            mapping.Clear();
        }

        public TVALUE TryGet(TKEY key)
        {
            TVALUE value;
            if (mapping.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                return default(TVALUE);
            }
        }

        public bool Exists(TKEY key)
        {
            foreach(var item in mapping)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public TVALUE Remap(TKEY key, TVALUE value)
        {
            if (Exists(key)) throw new Exception("Duplicate key");
            mapping.Add(key, value);
            return value;
        }
    }
}