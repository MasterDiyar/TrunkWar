using Godot;
using System;

public partial class UpgradeControl : Control
{
	Button upgradeButton, deleteButton;
	Label entityLabel;

	private Action _currentUpgradeAction;
	private Action _currentDeleteAction;

	public override void _Ready()
	{
		upgradeButton = GetNode<Button>("NinePatchRect/MarginContainer/VBoxContainer/HBoxContainer/upgrade");
		deleteButton = GetNode<Button>("NinePatchRect/MarginContainer/VBoxContainer/HBoxContainer/delete");
		entityLabel = GetNode<Label>("NinePatchRect/MarginContainer/VBoxContainer/Label");

	}

	public void Set(string name, Action onUpgrade, Action onDelete)
	{
		Clear();

		Show();

		entityLabel.Text = name;
		_currentUpgradeAction = onUpgrade;
		_currentDeleteAction = onDelete;

		upgradeButton.Pressed += onUpgrade;
		deleteButton.Pressed += onDelete;
	}

	public void Clear()
	{
		Hide();

		entityLabel.Text = "NAME";

		if (_currentUpgradeAction != null)
		{
			upgradeButton.Pressed -= _currentUpgradeAction;
			_currentUpgradeAction = null;
		}

		if (_currentDeleteAction != null)
		{
			deleteButton.Pressed -= _currentDeleteAction;
			_currentDeleteAction = null;
		}
	}

	private void OnUpgradePressed() => _currentUpgradeAction?.Invoke();
	private void OnDeletePressed() => _currentDeleteAction?.Invoke();

	public override void _Input(InputEvent @event)
	{
		if (@event is not InputEventMouseButton { Pressed: true } mouseEvent || !Visible) return;
		if (GetGlobalRect().HasPoint(mouseEvent.GlobalPosition)) return;
		Clear();
	}

}
