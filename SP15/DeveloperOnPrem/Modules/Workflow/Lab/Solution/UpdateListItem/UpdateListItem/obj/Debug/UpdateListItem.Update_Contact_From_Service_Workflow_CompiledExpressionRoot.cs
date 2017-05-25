namespace UpdateListItem.Update_Contact_From_Service {
    
    #line 17 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 18 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 19 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 20 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 21 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using Microsoft.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Student\Modules\Workflow\Lab\UpdateListItem\UpdateListItem\UpdateContactFromService\Workflow.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class Workflow : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
        private System.Activities.Activity rootActivity;
        
        private object dataContextActivities;
        
        private bool forImplementation = true;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string GetLanguage() {
            return "C#";
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((this.dataContextActivities == null)) {
                this.dataContextActivities = Workflow_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new Workflow_TypedDataContext2(locations, activityContext, true);
                }
                Workflow_TypedDataContext2 refDataContext0 = ((Workflow_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new Workflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext2_ForReadOnly valDataContext1 = ((Workflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new Workflow_TypedDataContext2(locations, activityContext, true);
                }
                Workflow_TypedDataContext2 refDataContext2 = ((Workflow_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new Workflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext2_ForReadOnly valDataContext3 = ((Workflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext4 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new Workflow_TypedDataContext3(locations, activityContext, true);
                }
                Workflow_TypedDataContext3 refDataContext5 = ((Workflow_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext6 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext7 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new Workflow_TypedDataContext3(locations, activityContext, true);
                }
                Workflow_TypedDataContext3 refDataContext8 = ((Workflow_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext8.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new Workflow_TypedDataContext3(locations, activityContext, true);
                }
                Workflow_TypedDataContext3 refDataContext9 = ((Workflow_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext9.GetLocation<int>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext10 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext11 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext12 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new Workflow_TypedDataContext3(locations, activityContext, true);
                }
                Workflow_TypedDataContext3 refDataContext13 = ((Workflow_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext13.GetLocation<string>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext14 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new Workflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext3_ForReadOnly valDataContext15 = ((Workflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new Workflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext2_ForReadOnly valDataContext16 = ((Workflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext17 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext18 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext18.GetLocation<string>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext19 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext20 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext21 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext21.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext22 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext22.GetLocation<string>(refDataContext22.ValueType___Expr22Get, refDataContext22.ValueType___Expr22Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext23 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext23.GetLocation<string>(refDataContext23.ValueType___Expr23Get, refDataContext23.ValueType___Expr23Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext24 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext24.GetLocation<string>(refDataContext24.ValueType___Expr24Get, refDataContext24.ValueType___Expr24Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext25 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext25.GetLocation<string>(refDataContext25.ValueType___Expr25Get, refDataContext25.ValueType___Expr25Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext26 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext27 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext27.GetLocation<string>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext28 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext28.GetLocation<string>(refDataContext28.ValueType___Expr28Get, refDataContext28.ValueType___Expr28Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new Workflow_TypedDataContext4(locations, activityContext, true);
                }
                Workflow_TypedDataContext4 refDataContext29 = ((Workflow_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext29.GetLocation<string>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext30 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext31 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext32 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext32.ValueType___Expr32Get();
            }
            if ((expressionId == 33)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext33 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext33.ValueType___Expr33Get();
            }
            if ((expressionId == 34)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext34 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext35 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = Workflow_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new Workflow_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                Workflow_TypedDataContext4_ForReadOnly valDataContext36 = ((Workflow_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext36.ValueType___Expr36Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.Location> locations) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((expressionId == 0)) {
                Workflow_TypedDataContext2 refDataContext0 = new Workflow_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                Workflow_TypedDataContext2_ForReadOnly valDataContext1 = new Workflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                Workflow_TypedDataContext2 refDataContext2 = new Workflow_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                Workflow_TypedDataContext2_ForReadOnly valDataContext3 = new Workflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext4 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                Workflow_TypedDataContext3 refDataContext5 = new Workflow_TypedDataContext3(locations, true);
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext6 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext7 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                Workflow_TypedDataContext3 refDataContext8 = new Workflow_TypedDataContext3(locations, true);
                return refDataContext8.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                Workflow_TypedDataContext3 refDataContext9 = new Workflow_TypedDataContext3(locations, true);
                return refDataContext9.GetLocation<int>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set);
            }
            if ((expressionId == 10)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext10 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext11 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext12 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                Workflow_TypedDataContext3 refDataContext13 = new Workflow_TypedDataContext3(locations, true);
                return refDataContext13.GetLocation<string>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set);
            }
            if ((expressionId == 14)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext14 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                Workflow_TypedDataContext3_ForReadOnly valDataContext15 = new Workflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                Workflow_TypedDataContext2_ForReadOnly valDataContext16 = new Workflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext17 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                Workflow_TypedDataContext4 refDataContext18 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext18.GetLocation<string>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set);
            }
            if ((expressionId == 19)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext19 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext20 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                Workflow_TypedDataContext4 refDataContext21 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext21.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set);
            }
            if ((expressionId == 22)) {
                Workflow_TypedDataContext4 refDataContext22 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext22.GetLocation<string>(refDataContext22.ValueType___Expr22Get, refDataContext22.ValueType___Expr22Set);
            }
            if ((expressionId == 23)) {
                Workflow_TypedDataContext4 refDataContext23 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext23.GetLocation<string>(refDataContext23.ValueType___Expr23Get, refDataContext23.ValueType___Expr23Set);
            }
            if ((expressionId == 24)) {
                Workflow_TypedDataContext4 refDataContext24 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext24.GetLocation<string>(refDataContext24.ValueType___Expr24Get, refDataContext24.ValueType___Expr24Set);
            }
            if ((expressionId == 25)) {
                Workflow_TypedDataContext4 refDataContext25 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext25.GetLocation<string>(refDataContext25.ValueType___Expr25Get, refDataContext25.ValueType___Expr25Set);
            }
            if ((expressionId == 26)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext26 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                Workflow_TypedDataContext4 refDataContext27 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext27.GetLocation<string>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set);
            }
            if ((expressionId == 28)) {
                Workflow_TypedDataContext4 refDataContext28 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext28.GetLocation<string>(refDataContext28.ValueType___Expr28Get, refDataContext28.ValueType___Expr28Set);
            }
            if ((expressionId == 29)) {
                Workflow_TypedDataContext4 refDataContext29 = new Workflow_TypedDataContext4(locations, true);
                return refDataContext29.GetLocation<string>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set);
            }
            if ((expressionId == 30)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext30 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext31 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext32 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext32.ValueType___Expr32Get();
            }
            if ((expressionId == 33)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext33 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext33.ValueType___Expr33Get();
            }
            if ((expressionId == 34)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext34 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext35 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                Workflow_TypedDataContext4_ForReadOnly valDataContext36 = new Workflow_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext36.ValueType___Expr36Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonName") 
                        && (Workflow_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"Person name: \" + PersonName") 
                        && (Workflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceUri + \"/Persons?$select=ID&$filter=Name eq \'\" + PersonName + \"\'\"") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "WebServiceQuery") 
                        && (Workflow_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"REST Query URI: \" + WebServiceQuery") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceQuery") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "ODataQueryResultCount") 
                        && (Workflow_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"Number of returned items: \" + ODataQueryResultCount") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "ODataQueryResultCount != 0") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonID") 
                        && (Workflow_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"Person ID: \" + PersonID") 
                        && (Workflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonID!=\"-1\"") 
                        && (Workflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceUri + \"/Persons(\" + PersonID + \")/PersonDetail\"") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "WebServiceQuery") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"REST Query URI: \" + WebServiceQuery") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceQuery") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonState") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonAge") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonCountry") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonCity") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "WebServiceResponse") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonStreetAddress") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonZipCode") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "PersonPhone") 
                        && (Workflow_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonAge") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonPhone") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonState") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 32;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonCity") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 33;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonZipCode") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 34;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonStreetAddress") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 35;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "PersonCountry") 
                        && (Workflow_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 36;
                return true;
            }
            expressionId = -1;
            return false;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> GetRequiredLocations(int expressionId) {
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Linq.Expressions.Expression GetExpressionTreeForExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) {
            if ((expressionId == 0)) {
                return new Workflow_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new Workflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new Workflow_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new Workflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new Workflow_TypedDataContext3(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new Workflow_TypedDataContext3(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new Workflow_TypedDataContext3(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new Workflow_TypedDataContext3(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new Workflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new Workflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new Workflow_TypedDataContext4(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr31GetTree();
            }
            if ((expressionId == 32)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr32GetTree();
            }
            if ((expressionId == 33)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr33GetTree();
            }
            if ((expressionId == 34)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr34GetTree();
            }
            if ((expressionId == 35)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr35GetTree();
            }
            if ((expressionId == 36)) {
                return new Workflow_TypedDataContext4_ForReadOnly(locationReferences).@__Expr36GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext1 : Workflow_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return Workflow_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext1_ForReadOnly : Workflow_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return Workflow_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext2 : Workflow_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string PersonName {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected Microsoft.Activities.DynamicValue WebServiceResponse {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string WebServiceQuery {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string PersonID {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string WebServiceUri {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 68 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
            WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr0Get() {
                
                #line 68 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr0Set(Microsoft.Activities.DynamicValue value) {
                
                #line 68 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
            WebServiceResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 80 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            PersonName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 80 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            PersonName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(string value) {
                
                #line 80 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
            PersonName = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 0)].Name != "PersonName") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "WebServiceResponse") 
                            || (locationReferences[(offset + 1)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "WebServiceQuery") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "PersonID") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "WebServiceUri") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return Workflow_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext2_ForReadOnly : Workflow_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string PersonName {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected Microsoft.Activities.DynamicValue WebServiceResponse {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string WebServiceQuery {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string PersonID {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string WebServiceUri {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 75 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
            WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr1Get() {
                
                #line 75 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 87 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            "Person name: " + PersonName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 87 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            "Person name: " + PersonName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 190 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
          PersonID!="-1";
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr16Get() {
                
                #line 190 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
          PersonID!="-1";
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 0)].Name != "PersonName") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "WebServiceResponse") 
                            || (locationReferences[(offset + 1)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "WebServiceQuery") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "PersonID") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "WebServiceUri") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return Workflow_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext3 : Workflow_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int ODataQueryResultCount;
            
            public Workflow_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 99 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            WebServiceQuery;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 99 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            WebServiceQuery;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(string value) {
                
                #line 99 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
            WebServiceQuery = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 127 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
            WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr8Get() {
                
                #line 127 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(Microsoft.Activities.DynamicValue value) {
                
                #line 127 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
            WebServiceResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 139 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
            ODataQueryResultCount;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr9Get() {
                
                #line 139 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            ODataQueryResultCount;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr9Set(int value) {
                
                #line 139 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
            ODataQueryResultCount = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr9Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr9Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 164 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  PersonID;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr13Get() {
                
                #line 164 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                  PersonID;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr13Set(string value) {
                
                #line 164 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                  PersonID = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr13Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr13Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.ODataQueryResultCount = ((int)(this.GetVariableValue((5 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((5 + locationsOffset), this.ODataQueryResultCount);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 6))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 6);
                }
                expectedLocationsCount = 6;
                if (((locationReferences[(offset + 5)].Name != "ODataQueryResultCount") 
                            || (locationReferences[(offset + 5)].Type != typeof(int)))) {
                    return false;
                }
                return Workflow_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext3_ForReadOnly : Workflow_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int ODataQueryResultCount;
            
            public Workflow_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 104 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            WebServiceUri + "/Persons?$select=ID&$filter=Name eq '" + PersonName + "'";
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 104 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            WebServiceUri + "/Persons?$select=ID&$filter=Name eq '" + PersonName + "'";
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 111 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            "REST Query URI: " + WebServiceQuery;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 111 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            "REST Query URI: " + WebServiceQuery;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 132 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            WebServiceQuery;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 132 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            WebServiceQuery;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 143 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
          WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr10Get() {
                
                #line 143 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
          WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 149 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            "Number of returned items: " + ODataQueryResultCount;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr11Get() {
                
                #line 149 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            "Number of returned items: " + ODataQueryResultCount;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 156 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
            ODataQueryResultCount != 0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr12Get() {
                
                #line 156 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
            ODataQueryResultCount != 0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 169 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
                  WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr14Get() {
                
                #line 169 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                  WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 176 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  "Person ID: " + PersonID;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr15Get() {
                
                #line 176 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                  "Person ID: " + PersonID;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            protected override void GetValueTypeValues() {
                this.ODataQueryResultCount = ((int)(this.GetVariableValue((5 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 6))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 6);
                }
                expectedLocationsCount = 6;
                if (((locationReferences[(offset + 5)].Name != "ODataQueryResultCount") 
                            || (locationReferences[(offset + 5)].Type != typeof(int)))) {
                    return false;
                }
                return Workflow_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext4 : Workflow_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string PersonAge {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected string PersonStreetAddress {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected string PersonCity {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected string PersonState {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            protected string PersonZipCode {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string PersonCountry {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((10 + locationsOffset), value);
                }
            }
            
            protected string PersonPhone {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 208 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                WebServiceQuery;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr18Get() {
                
                #line 208 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                WebServiceQuery;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr18Set(string value) {
                
                #line 208 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                WebServiceQuery = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr18Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr18Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 236 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
                WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr21Get() {
                
                #line 236 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr21Set(Microsoft.Activities.DynamicValue value) {
                
                #line 236 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                WebServiceResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr21Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr21Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 262 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonState;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr22Get() {
                
                #line 262 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonState;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr22Set(string value) {
                
                #line 262 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonState = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr22Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr22Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 253 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonAge;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr23Get() {
                
                #line 253 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonAge;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr23Set(string value) {
                
                #line 253 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonAge = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr23Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr23Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 268 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonCountry;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr24Get() {
                
                #line 268 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonCountry;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr24Set(string value) {
                
                #line 268 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonCountry = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr24Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr24Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 259 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonCity;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr25Get() {
                
                #line 259 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonCity;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr25Set(string value) {
                
                #line 259 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonCity = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr25Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr25Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 256 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonStreetAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr27Get() {
                
                #line 256 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonStreetAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr27Set(string value) {
                
                #line 256 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonStreetAddress = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr27Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr27Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 265 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonZipCode;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr28Get() {
                
                #line 265 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonZipCode;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr28Set(string value) {
                
                #line 265 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonZipCode = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr28Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr28Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 271 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                PersonPhone;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr29Get() {
                
                #line 271 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                PersonPhone;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr29Set(string value) {
                
                #line 271 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                
                PersonPhone = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr29Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr29Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 12))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 12);
                }
                expectedLocationsCount = 12;
                if (((locationReferences[(offset + 5)].Name != "PersonAge") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "PersonStreetAddress") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "PersonCity") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "PersonState") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "PersonZipCode") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "PersonCountry") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "PersonPhone") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                return Workflow_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class Workflow_TypedDataContext4_ForReadOnly : Workflow_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public Workflow_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public Workflow_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string PersonAge {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected string PersonStreetAddress {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected string PersonCity {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected string PersonState {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            protected string PersonZipCode {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string PersonCountry {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
            }
            
            protected string PersonPhone {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 213 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                WebServiceUri + "/Persons(" + PersonID + ")/PersonDetail";
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr17Get() {
                
                #line 213 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                WebServiceUri + "/Persons(" + PersonID + ")/PersonDetail";
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 220 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                "REST Query URI: " + WebServiceQuery;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr19Get() {
                
                #line 220 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                "REST Query URI: " + WebServiceQuery;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 241 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                WebServiceQuery;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr20Get() {
                
                #line 241 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                WebServiceQuery;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 248 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
                WebServiceResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr26Get() {
                
                #line 248 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                WebServiceResponse;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 295 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonAge;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr30Get() {
                
                #line 295 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonAge;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 298 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonPhone;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr31Get() {
                
                #line 298 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonPhone;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr32GetTree() {
                
                #line 307 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonState;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr32Get() {
                
                #line 307 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonState;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr32Get() {
                this.GetValueTypeValues();
                return this.@__Expr32Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr33GetTree() {
                
                #line 304 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonCity;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr33Get() {
                
                #line 304 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonCity;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr33Get() {
                this.GetValueTypeValues();
                return this.@__Expr33Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr34GetTree() {
                
                #line 310 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonZipCode;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr34Get() {
                
                #line 310 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonZipCode;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr34Get() {
                this.GetValueTypeValues();
                return this.@__Expr34Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr35GetTree() {
                
                #line 301 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonStreetAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr35Get() {
                
                #line 301 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonStreetAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr35Get() {
                this.GetValueTypeValues();
                return this.@__Expr35Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr36GetTree() {
                
                #line 313 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      PersonCountry;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr36Get() {
                
                #line 313 "C:\STUDENT\MODULES\WORKFLOW\LAB\UPDATELISTITEM\UPDATELISTITEM\UPDATECONTACTFROMSERVICE\WORKFLOW.XAML"
                return 
                      PersonCountry;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr36Get() {
                this.GetValueTypeValues();
                return this.@__Expr36Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 12))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 12);
                }
                expectedLocationsCount = 12;
                if (((locationReferences[(offset + 5)].Name != "PersonAge") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "PersonStreetAddress") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "PersonCity") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "PersonState") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "PersonZipCode") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "PersonCountry") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "PersonPhone") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                return Workflow_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
