﻿/*
 * To add Offline Sync Support:
 *  1) Add the NuGet package Microsoft.Azure.Mobile.Client.SQLiteStore (and dependencies) to all client projects
 *  2) Uncomment the #define OFFLINE_SYNC_ENABLED
 *
 * For more information, see: http://go.microsoft.com/fwlink/?LinkId=620342
 */
//#define OFFLINE_SYNC_ENABLED

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NoKnowApplication.Entities;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#endif

namespace NoKnowApplication.Services
{
    public partial class GemeindeService
    {
        static GemeindeService defaultInstance = new GemeindeService();
        MobileServiceClient client;

        IMobileServiceTable<GemeindeEntity> gemeindeTable;

        private GemeindeService()
        {
            this.client = MobileService.MobileServiceClient;  
            this.gemeindeTable = client.GetTable<GemeindeEntity>();
        }

        public static GemeindeService DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }
  
        public async Task<ObservableCollection<GemeindeEntity>> GetAllGemeinden(bool syncItems = false)
        {
            try
            {
                IEnumerable<GemeindeEntity> items = await gemeindeTable.ToEnumerableAsync();
                return new ObservableCollection<GemeindeEntity>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            }
            catch (Exception e)
            {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }
    }
}
