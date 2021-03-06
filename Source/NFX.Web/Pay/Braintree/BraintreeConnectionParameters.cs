/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2014 Dmitriy Khmaladze, IT Adapter Inc / 2015-2016 Aum Code LLC
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/
using NFX.Environment;
using NFX.Security;

namespace NFX.Web.Pay.Braintree
{
  public class BraintreeConnectionParameters : PayConnectionParameters
  {
    public const string BRAINTREE_REALM = "braintree";

    public BraintreeConnectionParameters(): base() { }
    public BraintreeConnectionParameters(IConfigSectionNode node): base(node) { }
    public BraintreeConnectionParameters(string connectString, string format = Configuration.CONFIG_LACONIC_FORMAT)
      : base(connectString, format) { }

    public override void Configure(IConfigSectionNode node)
    {
      base.Configure(node);

      var merchantId = node.AttrByName("merchant-id").ValueAsString();
      if (merchantId.IsNullOrWhiteSpace())
        User = User.Fake; //throw new PaymentException("Braintree: " + StringConsts.PAYMENT_BRAINTREE_MERCHANT_ID_REQUIRED.Args(this.GetType().FullName));

      var accessToken = node.AttrByName("access-token").ValueAsString();
      if (accessToken.IsNotNullOrWhiteSpace())
        User = new User(new BraintreeAuthCredentials(merchantId, accessToken), new AuthenticationToken(BRAINTREE_REALM, accessToken), merchantId, Rights.None);
      else
      {
        var publicKey = node.AttrByName("public-key").ValueAsString();
        var privateKey = node.AttrByName("private-key").ValueAsString();
        if (publicKey.IsNullOrWhiteSpace() || privateKey.IsNullOrWhiteSpace())
          User = User.Fake; //throw new PaymentException("Braintree: " + StringConsts.PAYMENT_BRAINTREE_CREDENTIALS_REQUIRED.Args(this.GetType().FullName));

        User = new User(new BraintreeCredentials(merchantId, publicKey, privateKey), new AuthenticationToken(BRAINTREE_REALM, publicKey), merchantId, Rights.None);
      }
    }
  }
}