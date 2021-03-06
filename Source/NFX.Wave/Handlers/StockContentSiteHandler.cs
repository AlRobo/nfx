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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NFX;
using NFX.Wave;
using NFX.Wave.Handlers;
using NFX.Environment;

namespace NFX.Wave.Handlers
{
  /// <summary>
  /// This handler serves the embedded content of NFX.Wave library
  /// </summary>
  public class StockContentSiteHandler : EmbeddedSiteHandler
  {
    public StockContentSiteHandler(WorkDispatcher dispatcher, string name, int order, WorkMatch match)
                          : base(dispatcher, name, order, match){}


    public StockContentSiteHandler(WorkDispatcher dispatcher, IConfigSectionNode confNode)
                          : base(dispatcher, confNode) {}


    public override string RootResourcePath
    {
      get { return "NFX.Wave.Templatization.StockContent.Embedded"; }
    }

    public override bool SupportsEnvironmentBranching
    {
      get { return false; }
    }

    protected override IEnumerable<EmbeddedSiteHandler.IAction> GetActions()
    {
      yield break;
    }
  }


}
