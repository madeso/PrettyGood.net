using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Localization
{
	public class Str
	{
		public override string ToString()
		{
			return Value;
		}

		public string Value
		{
			get
			{
				if (IsDefault == true)
				{
					return Default;
				}
				else
				{
					return mValue;
				}
			}
			set
			{
				bool wasDefault = IsDefault;
				mValue = value;
				IsDefault = false;
				if( wasDefault == false ) fireChange();
			}
		}
		private string mValue = "";
		private Dictionary<string, Arg> mArguments = new Dictionary<string, Arg>();

		public string matchArgument(string name, object value)
		{
			return mArguments[name].Format(value);
		}

		public Format Format
		{
			get
			{
				return new Format(this);
			}
		}

		public void setup(string name, Module mod, List<Arg> args)
		{
			mName = name;
			mod.add(this);
			setDefault(mName);
			foreach (Arg arg in args)
			{
				mArguments.Add(arg.Name, arg);
			}
		}

		public string Name
		{
			get
			{
				return mName;
			}
		}
		private string mName = "";

		public string Default
		{
			get
			{
				return mDefault;
			}
		}
		private string mDefault = "";

		public void setDefault()
		{
			IsDefault = true;
		}

		private static Regex sExtractDefault = new Regex(@"_*(?<let>[A-Z])");

		private bool mAllowDefaultChange = false;
		private void setDefault(string val)
		{
			if (mAllowDefaultChange)
			{
				mDefault = sExtractDefault.Replace(val, @" ${let}").Trim();
			}
		}

		public Str()
		{
			mDefault = "";
			mAllowDefaultChange = true;
		}

		public Str(string aDefault)
		{
			mDefault = aDefault;
			mAllowDefaultChange = false;
		}

		public delegate void delOnChange(Str str);
		public event delOnChange OnChange;

		private void fireChange()
		{
			if (OnChange != null) OnChange(this);
		}

		public Str bind(System.Windows.Forms.Control c)
		{
			c.Text = Value;
			OnChange += delegate(Str s) { c.Text = s.Value; };
			return this;
		}

		public Str bind(System.Windows.Forms.ToolStripItem c)
		{
			c.Text = Value;
			OnChange += delegate(Str s) { c.Text = s.Value; };
			return this;
		}

		public Str bind(System.Windows.Forms.TreeNode c)
		{
			c.Text = Value;
			OnChange += delegate(Str s) { c.Text = s.Value; };
			return this;
		}

		public bool IsDefault
		{
			get
			{
				return mIsDefault;
			}
			set
			{
				if (mIsDefault != value)
				{
					mIsDefault = value;
					fireChange();
				}
			}
		}
		private bool mIsDefault = true;
	}
}
