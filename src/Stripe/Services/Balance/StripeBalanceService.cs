﻿using System.Collections.Generic;

#if NET40
using System.Threading.Tasks;
#endif

namespace Stripe
{
    public class StripeBalanceService : StripeService
    {
        public StripeBalanceService(string apiKey = null) : base(apiKey) { }

        public virtual StripeBalance Get()
        {
            var response = Requestor.GetString(Urls.Balance, ApiKey);
            
            return Mapper<StripeBalance>.MapFromJson(response);
        }

#if NET40
        public virtual async Task<StripeBalance> GetAsync()
        {
            var response = await Requestor.GetStringAsync(Urls.Balance, ApiKey);

            return Mapper<StripeBalance>.MapFromJson(response);
        }
#endif

        public virtual StripeBalanceTransaction Get(string id)
        {
            var url = FormatGetWithIdUrl(id);

            var response = Requestor.GetString(url, ApiKey);

            return Mapper<StripeBalanceTransaction>.MapFromJson(response);
        }

#if NET40
        public virtual async Task<StripeBalanceTransaction> GetAsync(string id)
        {
            var url = FormatGetWithIdUrl(id);

            var response = await Requestor.GetStringAsync(url, ApiKey);

            return Mapper<StripeBalanceTransaction>.MapFromJson(response);
        }
#endif

        public virtual IEnumerable<StripeBalanceTransaction> List(StripeBalanceTransactionListOptions options = null)
        {
            var url = FormatListUrl(options);

            var response = Requestor.GetString(url, ApiKey);

            return Mapper<StripeBalanceTransaction>.MapCollectionFromJson(response);
        }

#if NET40
        public virtual async Task<IEnumerable<StripeBalanceTransaction>> ListAsync(StripeBalanceTransactionListOptions options = null)
        {
            var url = FormatListUrl(options);

            var response = await Requestor.GetStringAsync(url, ApiKey);

            return Mapper<StripeBalanceTransaction>.MapCollectionFromJson(response);
        }
#endif

        private string FormatListUrl(StripeBalanceTransactionListOptions options)
        {
            var url = Urls.BalanceTransactions;
            url = this.ApplyAllParameters(options, url, true);
            return url;
        }

        private string FormatGetWithIdUrl(string id)
        {
            var url = string.Format(Urls.SpecificBalanceTransaction, id);
            url = this.ApplyAllParameters(null, url, false);
            return url;
        }
    }
}
