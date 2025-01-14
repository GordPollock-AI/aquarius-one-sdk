﻿using CommandLine;
using ONE.Utilities;
using ONE;
using System;
using System.Threading.Tasks;
using ONE.Models.CSharp;

namespace Aquarius.ONE.Test.ConsoleApp.Commands
{

    // data -a create -g 8202c17a-30c0-454c-81fd-8ac8699401a7

    [Verb("data", HelpText = "Manage Data.")]
    public class DataCommand: ICommand
    {
        [Option('g', "guid", Required = true, HelpText = "Telemetry GUID")]
        public string Guid { get; set; }

        [Option('a', "action", Required = true, HelpText = "Action")]
        public string Action { get; set; }

        async Task<int> ICommand.Execute(ClientSDK clientSDK)
        {
            switch (Action.ToUpper())
            {
                case "GET":
                    {
                        var data = await clientSDK.Data.GetDataAsync(Guid, DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1));
                        if (data != null)
                        {
                            foreach (var item in data)
                            {
                                Console.WriteLine($"{item.DateTimeUTC.ToDateTime().ToString("MM/dd/yyyy hh:mm:ss")} {item.Value} {item.StringValue}");
                            }
                            return 1;
                        }
                        else
                            return 0;

                    }
                case "CREATE":
                    {
                        HistorianDatas historianDatas = new HistorianDatas();
                        historianDatas.Items.Add(new HistorianData
                        {
                            DateTimeUTC = DateTimeHelper.ToJsonTicksDateTime(DateTime.Now),
                            PropertyBag = "",
                            Value = 5,
                            StringValue = "<10"

                        });
                        var result = await clientSDK.Data.SaveDataAsync(Guid, historianDatas);
                        if (result)
                            return 0;
                        else
                        {
                            Console.WriteLine(result);
                            return 1;
                        }
                    }
                default:
                    Console.WriteLine($"Action Not Recognized: {Action}");
                    return 0;
            }
        }
    }
}
