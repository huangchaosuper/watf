using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HP.ST.Fwk.RunTimeFWK.Utilities;
    using HP.ST.Fwk.RunTimeFWK.BindingFWK;
    
    namespace Script
    {
    
    public class TestEntities
    {
    public ISTRunTimeContext Context = null;
    public HP.ST.Ext.BasicActivities.StartActivity StartActivity1 = null;
    public HP.ST.Fwk.RunTimeFWK.CompositeActivities.Loop<Loop2Input> Loop2 = null;
    public HP.ST.Ext.BasicActivities.EndActivity EndActivity3 = null;
    public HP.ST.Fwk.RunTimeFWK.CompositeActivities.Sequence Sequence13 = null;
    public JavaUnit.JavaUnitActivity JavaUnitActivity11 = null;
    
    }
    
    }
    