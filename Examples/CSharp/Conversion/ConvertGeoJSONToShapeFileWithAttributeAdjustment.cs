﻿using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Conversion
{
    class ConvertGeoJSONToShapeFileWithAttributeAdjustment
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();
            //ExStart: ConvertGeoJSONToShapeFileWithAttributeAdjustment
            ConversionOptions options = new ConversionOptions();

            options.AttributesConverter = new AttributesConverterExample();

            VectorLayer.Convert(dataDir + "input.json", Drivers.GeoJson, dataDir + "ConvertGeoJSONToShapeFileWithAttributeAdjustment_out.shp", Drivers.Shapefile, options);
            //ExEnd: ConvertGeoJSONToShapeFileWithAttributeAdjustment
        }

        //ExStart: AttributesConverterExample
        private class AttributesConverterExample : IAttributesConverter
        {
            public void ModifyAttribute(FeatureAttribute attribute)
            {
                switch (attribute.Name)
                {
                    case "name":
                        attribute.Width = 10;
                        break;
                    case "age":
                        attribute.Width = 3;
                        attribute.Precision = 0;
                        break;
                }
            }
        }
        //ExEnd: AttributesConverterExample

    }
}
