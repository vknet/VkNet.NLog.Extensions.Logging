#if NET40
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;

namespace System
{
	[Serializable]
	public sealed class WeakReference<T> : ISerializable
		where T : class
	{
		internal IntPtr m_handle;

		public WeakReference(T target)
			: this(target, false)
		{
		}

		public WeakReference(T target, bool trackResurrection)
		{
			Create(target, trackResurrection);
		}

		internal WeakReference(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException(nameof(info));
			}

			Create((T) info.GetValue("TrackedObject", typeof(T)), info.GetBoolean("TrackResurrection"));
		}

		public bool TryGetTarget(out T target)
		{
			var target1 = Target;
			target = target1;

			return target1 != null;
		}

		public void SetTarget(T target)
		{
			Target = target;
		}

		private extern T Target
		{
			[SecuritySafeCritical, MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[SecuritySafeCritical, MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern ~WeakReference();

		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException(nameof(info));
			}

			info.AddValue("TrackedObject", Target, typeof(T));
			info.AddValue("TrackResurrection", IsTrackResurrection());
		}

		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Create(T target, bool trackResurrection);

		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool IsTrackResurrection();
	}
}
#endif