/***************************************************************
    *  DO NOT EDIT THIS FILE!
    *         
    *  This file is automatically generated by HP Service Test.
    *  Manually changing the contents of this file may result in 
    *  loss of information.
    *          
    *  To edit the test, open the file ‘WATFDemo.st’ 
    *  in HP Service Test.
     ***************************************************************/
    
    namespace Script
    {
    using System;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using HP.ST.Fwk.ReporterFWK;
    using HP.ST.Shared.Utilities;
    using HP.ST.Ext.BindingImpl.Getters;
    using HP.ST.Ext.BindingImpl.Setters;
    using HP.ST.Fwk.RunTimeFWK.BindingFWK;
    using HP.ST.Fwk.RunTimeFWK.BindingFWK.PropInfo;
    using HP.ST.Fwk.RunTimeFWK.BindingFWK.Getters;
    using HP.ST.Fwk.RunTimeFWK.BindingFWK.Setters;
    using HP.ST.Fwk.RunTimeFWK;
    using HP.ST.Fwk.RunTimeFWK.Utilities;
    using HP.ST.Fwk.RunTimeFWK.HelperClasses;
    using HP.ST.Fwk.RunTimeFWK.CompositeActivities;
    using HP.ST.Ext.BindingImpl.Setters.DataSourceSetters;
    using HP.ST.Fwk.JVMLoader;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;
    using HP.ST.Fwk.SOAReplayAPI;
    using HP.ST.Fwk.UFTLicensing;
    
    
    public partial class WorkFlowScript : Sequence
    {
        // Create context for this flow
    	ISTRunTimeContext _context;
    	TestUserCode _userCode = null;
    	TestEntities _flow = null;
    	static Reporter reporter;
    	int reportLevelInTree;
        HP.ST.Fwk.ReportCreator.QTPEngine.QTPEngineReportCreator reportCreator;
    	
    	
        public IEnumerable<FeaturesGroup> LicensedFeatures
        {
        
        get
        {
        List<FeaturesGroup> features = new List<FeaturesGroup>();
        return features;
        
        }
        
        }
        
        public WorkFlowScript()
            : base(new STRunTimeContext(), "test")
        {
        	//Constuctor for check license
        	
        }
        
        public WorkFlowScript(ISTRunTimeContext ctx)
            : base(ctx, "test")
            
        {
        	this._context = ctx;
        }
        
        internal void InitializeComponent()
        {
        	LoadTestInput();
        		
        	// Intialize Reporter
        	string reportDBDir = Path.Combine(this._context.ReportDirectory, @"Report");
        	CleanupReport(reportDBDir);        	
        	string reportDBPath = Path.Combine(reportDBDir, "VTDReport.mdb");        	
        	if (reporter == null)
        	{
        		reporter = new Reporter(reportDBPath);
        	}
        	_context.Reporter = reporter;
        	
        	InitializeEncryptionManagerValues();
        
        	_userCode = new TestUserCode();
            _flow = _userCode;
            _flow.Context=this._context;
            
            
        
        	_flow.StartActivity1 = new HP.ST.Ext.BasicActivities.StartActivity(_context,"StartActivity1");
            _flow.Loop2 = new HP.ST.Fwk.RunTimeFWK.CompositeActivities.Loop<Loop2Input>(_context,"Loop2",LoopType.For);
            _flow.EndActivity3 = new HP.ST.Ext.BasicActivities.EndActivity(_context,"EndActivity3");
            _flow.Sequence13 = new HP.ST.Fwk.RunTimeFWK.CompositeActivities.Sequence(_context,"Sequence13");
            _flow.JavaUnitActivity11 = new JavaUnit.JavaUnitActivity(_context,"JavaUnitActivity11");
            _flow.StartActivity1.Comment = @"";
            _flow.StartActivity1.Name = @"Start";
            this.Activities.Add (_flow.StartActivity1);
            _flow.Loop2.ConditionAsString = @"Run for 1 iteration";
            _flow.Loop2.NumberOfIterations = (int)1;
            _flow.Loop2.Comment = @"";
            _flow.Loop2.Name = @"Test Flow";
            _flow.Loop2.Activities.Add (_flow.Sequence13);
            this.Activities.Add (_flow.Loop2);
            _flow.EndActivity3.Comment = @"";
            _flow.EndActivity3.Name = @"End";
            this.Activities.Add (_flow.EndActivity3);
            _flow.Sequence13.Comment = @"";
            _flow.Sequence13.Name = @"Sequence13";
            _flow.Sequence13.Activities.Add (_flow.JavaUnitActivity11);
            _flow.JavaUnitActivity11.JavaPath = @"";
            _flow.JavaUnitActivity11.ClassPath = @"";
            _flow.JavaUnitActivity11.InputParams = @"";
            _flow.JavaUnitActivity11.ExpectedData = @"";
            _flow.JavaUnitActivity11.Comment = @"";
            _flow.JavaUnitActivity11.Name = @"JavaUnitDriver11";
            
        }
        
        internal void InitializeEncryptionManagerValues()
        {
        
        }
        	
    	protected override STExecutionResult ExecuteStep()
        {
            return base.ExecuteStep();
        }
    
        public void Start()
        {
    		Workflow_Executing();
            this.ExecuteStep();
            WorkFlowScript_Completed();
        }
    
        public static void CopyDirectory(string Src, string Dst)
        {
            String[] Files;
    
            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                    CopyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory
                else
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }
        
        private void CleanupReport(string reportDBDir)
        {                
            string reportTemplateDir = Path.Combine(ServiceTestRunner.GetInstallPath(),@"bin\ReportResources");                
            try
            {
            	CopyDirectory(reportTemplateDir, reportDBDir);
            }
            catch //(Exception ex)
            {
                //TODO LoggingService.Warn("Report Cleanup Error", ex);
            }
        }
    
        void Workflow_Executing()
        {   	
        	// Init report creator
    		this.reportCreator = new HP.ST.Fwk.ReportCreator.QTPEngine.QTPEngineReportCreator();
    		this.reportLevelInTree = reportCreator.Init(_context.EnvironmentProfile.GetVariableValue("TestName"), _context);
                
            STActivityBase activity = this;
            string workflowID = activity.GetHashCode().ToString();
            ReportNodeCreationData newNodeData =
                new ReportNodeCreationData(workflowID, workflowID, DateTime.Now);
            reporter.CreateReportNode(newNodeData);
            
            ReportInfoData newReportData = new ReportInfoData(workflowID, ReportKeywords.TypeKeywordTag, this.GetType().ToString());
            reporter.SendReportData(newReportData);
    
            newReportData = new ReportInfoData(workflowID, ReportKeywords.NameKeywordTag, this.Name);
            //TrackData(ReportInfoData.InfoDataTag, newReportData);
            reporter.SendReportData(newReportData);            
        }
        
        void WorkFlowScript_Completed()
        {
            	SaveTestOutput();
            	
            	//Dispose reporter inorder to close connection to report DB
            	this._context.Reporter.Dispose();
            	
            	// Run report creator
    			reportCreator.RunOnDBAndCreateFiles();
    			
    			// Write all snapshots to disk
    			this._context.SnapshotManager.WriteSnapshotsToDisk();
    			
    			
        }
        
        void Workflow_Faulting()
        {
            SaveTestOutput();
    
            //Dispose reporter inorder to close connection to report DB
            this._context.Reporter.Dispose();
    
            // Run report creator
            reportCreator.RunOnDBAndCreateFiles();
            
            // Write all snapshots to disk
            this._context.SnapshotManager.WriteSnapshotsToDisk();
        }
        
        private void SaveTestOutput()
        {
        	try
        	{
        		TestOutput testOutput = new TestOutput(_context.TestOutputParameters);
        		testOutput.Status = _context.Status;
        		_context.ReplayClient.OnTestCompleted(testOutput);
        	}
        	catch(Exception ex)
        	{
        		_context.UserLogger.Error("Could not save test output", ex);        		
        	}        
        }
    }
    
    public partial class VuserClass
    {
    	public static string[] CommandLineArguments;
    	
    	
    	public static void InitJavaEnv(string classPath, string additionalVMargs)
    	{
    		JVMLoader.LoadJVM(classPath, additionalVMargs);
    	}
    	
    	
    		
        public VuserClass()
        {
    		UpdateDllsLocation();
    	}
    	
        public int STAction()
        {	
    	    STRunTimeContext ctx = new STRunTimeContext(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName, string.Empty);
            WorkFlowScript script = new WorkFlowScript(ctx);
            script.InitializeComponent();
            script.Start();       
            
            return 0;
        }
        
        public void NotifyLicenseException(string msg)
        {
        		
    		try
    		{
    		    STRunTimeContext ctx = new STRunTimeContext(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName, string.Empty);
                WorkFlowScript script = new WorkFlowScript(ctx);
                script.InitializeComponent();
                script.Context.ReplayClient.OnLicenseFailure(msg);
                
            }
            catch (Exception)
            {
    			// todo: log the error message
            }
            
        }
        
    }
    
    }
    