package mono.com.microsoft.appcenter.distribute;


public class DistributeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.appcenter.distribute.DistributeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNoReleaseAvailable:(Landroid/app/Activity;)V:GetOnNoReleaseAvailable_Landroid_app_Activity_Handler:Microsoft.AppCenter.Distribute.Android.IDistributeListenerInvoker, Microsoft.AppCenter.Distribute\n" +
			"n_onReleaseAvailable:(Landroid/app/Activity;Lcom/microsoft/appcenter/distribute/ReleaseDetails;)Z:GetOnReleaseAvailable_Landroid_app_Activity_Lcom_microsoft_appcenter_distribute_ReleaseDetails_Handler:Microsoft.AppCenter.Distribute.Android.IDistributeListenerInvoker, Microsoft.AppCenter.Distribute\n" +
			"";
		mono.android.Runtime.register ("Microsoft.AppCenter.Distribute.Android.IDistributeListenerImplementor, Microsoft.AppCenter.Distribute", DistributeListenerImplementor.class, __md_methods);
	}


	public DistributeListenerImplementor ()
	{
		super ();
		if (getClass () == DistributeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Microsoft.AppCenter.Distribute.Android.IDistributeListenerImplementor, Microsoft.AppCenter.Distribute", "", this, new java.lang.Object[] {  });
	}


	public void onNoReleaseAvailable (android.app.Activity p0)
	{
		n_onNoReleaseAvailable (p0);
	}

	private native void n_onNoReleaseAvailable (android.app.Activity p0);


	public boolean onReleaseAvailable (android.app.Activity p0, com.microsoft.appcenter.distribute.ReleaseDetails p1)
	{
		return n_onReleaseAvailable (p0, p1);
	}

	private native boolean n_onReleaseAvailable (android.app.Activity p0, com.microsoft.appcenter.distribute.ReleaseDetails p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
