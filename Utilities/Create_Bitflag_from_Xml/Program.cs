// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//

using System;
using System.IO;
using System.Text;

if (File.Exists("input.txt"))
{
	string[] _fileLines_ = File.ReadAllLines("input.txt");

	StringBuilder _outputStringBuilder_ = new StringBuilder();
	string[][] _fileLineParts_ = new string[_fileLines_.Length - 2][];
	int _longestConstantLength_ = 0;
	int _totalValues_ = 0;


	// Create initial lines
	_outputStringBuilder_.Append("	// " + _fileLines_[0].Split("\r", StringSplitOptions.TrimEntries)[0] + "\r\n");
	_outputStringBuilder_.Append("	/// <summary>\r\n");
	_outputStringBuilder_.Append("	/// ");
	_outputStringBuilder_.Append(_fileLines_[1].Split("\r", StringSplitOptions.TrimEntries)[0] + "\r\n");
	_outputStringBuilder_.Append("	/// </summary>\r\n");

	string[] _firstLineParts_ = _fileLines_[0].Split("\"", StringSplitOptions.TrimEntries);
	_outputStringBuilder_.Append("	[Flags]\r\n");
	_outputStringBuilder_.Append("	public enum ");
	_outputStringBuilder_.Append(_firstLineParts_[1]);
	_outputStringBuilder_.Append(" : ");
	_outputStringBuilder_.Append(_firstLineParts_[3]);
	_outputStringBuilder_.Append("\r\n");

	_outputStringBuilder_.Append("	{\r\n");
	_outputStringBuilder_.Append("		// ReSharper disable InconsistentNaming\r\n");

	for (ushort _i_ = 0; _i_ < _fileLineParts_.Length; _i_++)
	{
		string[] _currentLineParts_ = _fileLines_[_i_ + 2].Split("\"", StringSplitOptions.TrimEntries);

		if (_currentLineParts_.Length >= 5)
		{
			_currentLineParts_[4] = _currentLineParts_[4].Split(">", StringSplitOptions.TrimEntries)[1];
			_currentLineParts_[4] = _currentLineParts_[4].Split("<", StringSplitOptions.TrimEntries)[0];
		}

		_fileLineParts_[_i_] = _currentLineParts_;

		// Find out which constant is the longest and store it's length.
		if (_currentLineParts_[3].Length > _longestConstantLength_)
		{
			_longestConstantLength_ = _currentLineParts_[3].Length;
		}

		_totalValues_++;
	}

	// Round the longest length up to the next multiple of 4.
	int _longestConstantLengthRoundedUp_ = (int)Math.Ceiling((double)_longestConstantLength_ / 4) * 4;
	bool _isLongestLengthDivisibleByFour_ = (_longestConstantLengthRoundedUp_ == _longestConstantLength_);

	for (ushort _i_ = 0; _i_ < _fileLineParts_.Length; _i_++)
	{
		_outputStringBuilder_.Append("		");				// Prepend leading whitespaces
		_outputStringBuilder_.Append(_fileLineParts_[_i_][3]);	// Add the line's constant

		if (_fileLineParts_[_i_][3].Length < _longestConstantLengthRoundedUp_)	// If this const is shorter than the longest, some padding needs to be added between it and the =
		{
			int _numberOfTabsToAdd_ = (int)Math.Ceiling((double)(_longestConstantLengthRoundedUp_ - _fileLineParts_[_i_][3].Length) / 4);

			if ((_numberOfTabsToAdd_ > 0) && (_isLongestLengthDivisibleByFour_ == false))
			{
				_numberOfTabsToAdd_ -= 1;	// Subtract 1 because the = append below adds the last tab.
			}

			_outputStringBuilder_.Append('	', _numberOfTabsToAdd_);	// Append the number of tabs required to align all = signs with each other.
		}

		_outputStringBuilder_.Append("	= ");				// Equals sign

		int _bitflagValue_ = Convert.ToInt32(_fileLineParts_[_i_][1]);
		string _bitflagValueString_ = "0b" + Convert.ToString((int)Math.Pow(2, _bitflagValue_), 2).PadLeft(_totalValues_, '0');
		_outputStringBuilder_.Append(_bitflagValueString_);	// Add the enum value

		if (_i_ < _fileLineParts_.Length - 1)
		{
			_outputStringBuilder_.Append(',');				// Close this enum param if it's not the last one
		}
		else if ((_fileLineParts_[_i_].Length >= 5) && (_fileLineParts_[_i_][4] != string.Empty))
		{
			_outputStringBuilder_.Append(' ');				// Add a space for the last line to align last comment with ones above
		}

		if ((_fileLineParts_[_i_].Length >= 5) && (_fileLineParts_[_i_][4] != string.Empty))
		{
			_outputStringBuilder_.Append(" // ");				// Add start of comment
			_outputStringBuilder_.Append(_fileLineParts_[_i_][4]);	// Add the enum value's comment
		}
		_outputStringBuilder_.Append("\r\n");				// End of line
	}

	_outputStringBuilder_.Append("		// ReSharper restore InconsistentNaming\r\n");
	File.WriteAllText("output.txt", _outputStringBuilder_.ToString());
}
else
{
	File.WriteAllBytes("input.txt", Array.Empty<byte>());
}
