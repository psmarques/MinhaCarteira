using MinhaCarteiraRazor.Core.DTO;
using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MinhaCarteiraRazor.Core.Util
{
    public class Conversor
    {
        public IEnumerable<TopFiveDTO> ConverterCarteiraParaTopFive(IEnumerable<Carteira> lstCarteira)
        {
            var r = new List<TopFiveDTO>();

            foreach (var item in lstCarteira)
            {
                var d = new TopFiveDTO();

                d.Id = item.Id;
                d.Nome = item.Usuario.Nome + " - " + item.Nome;

                if (item.Investido > 0)
                    d.Resultado = Math.Round(item.Atual / item.Investido - 1, 2, MidpointRounding.AwayFromZero);
                else
                    d.Resultado = 0;

                r.Add(d);
            }

            return r;
        }

        public string ConverterObjectParaJson<T>(T item)
        {
            var ret = string.Empty;

            var serializer = new DataContractJsonSerializer(typeof(T));

            using (var mem = new MemoryStream())
            {
                serializer.WriteObject(mem, item);

                ret = Encoding.UTF8.GetString(mem.ToArray());
                mem.Close();
            }

            return ret;
        }

        public T ConverterJsonParaObject<T>(string item) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            T res;

            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(item)))
            {
                res = serializer.ReadObject(mem) as T;
            }

            return res;
        }

        public DateTime ConverterUnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }
}
