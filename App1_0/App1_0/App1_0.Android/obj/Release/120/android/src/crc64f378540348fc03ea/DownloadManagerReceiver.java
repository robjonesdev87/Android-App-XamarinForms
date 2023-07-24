package crc64f378540348fc03ea;


public class DownloadManagerReceiver
	extends com.microsoft.appcenter.distribute.DownloadManagerReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Microsoft.AppCenter.Distribute.DownloadManagerReceiver, Microsoft.AppCenter.Distribute", DownloadManagerReceiver.class, __md_methods);
	}


	public DownloadManagerReceiver ()
	{
		super ();
		if (getClass () == DownloadManagerReceiver.class)
			mono.android.TypeManager.Activate ("Microsoft.AppCenter.Distribute.DownloadManagerReceiver, Microsoft.AppCenter.Distribute", "", this, new java.lang.Object[] {  });
	}

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
