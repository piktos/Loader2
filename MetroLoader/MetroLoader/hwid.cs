using System;
using System.Collections.Generic;

using Microsoft.Win32;

namespace HWIDGrabber
{
    class HWDI
    {
        public static string GetMachineGuid()
        {
            var location = @"SOFTWARE\Microsoft\Cryptography";
            var name = "MachineGuid";

            using (var localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException($"Key Not Found: {location}");

                    var machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException($"Index Not Found: {name}");

                    return machineGuid.ToString();
                }
            }
        }
    }
}