
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Org.BouncyCastle.Bcpg.OpenPgp;

namespace org.GraphDefined.OpenDataAPI.OverpassAPI
{

    public static class Extentions
    {

        #region RunAll(this OverpassQuery, Filename)

        /// <summary>
        /// Standard workflow...
        /// </summary>
        /// <param name="OverpassQuery">An Overpass query.</param>
        /// <param name="FilenamePrefix">A file name prefix.</param>
        public static void RunAll(this OverpassQuery  OverpassQuery,
                                  String              FilenamePrefix,
                                  PgpSecretKey        SecretKey,
                                  String              Passphrase)
        {

            OverpassQuery.
                ToFile       (FilenamePrefix + ".json").
                ToGeoJSONFile(FilenamePrefix + ".geojson").
                SignGeoJSON  (FilenamePrefix + ".geojson.sig",  SecretKey, Passphrase).
                SignGeoJSON  (FilenamePrefix + ".geojson.bsig", SecretKey, Passphrase, ArmoredOutput: false).
                ContinueWith(task => Console.WriteLine(FilenamePrefix + ".* files are ready!")).
                Wait();

        }

        #endregion

    }

}
