   M S B A M L   `   `   `  ����D  @AlmacenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AlmacenV2.ViewAlmacenV2.View  5   	   *    $AlmacenV2.View.TelefonoProveedorView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AlmacenV2.View     5   	   $	��450��5   "   $	��800��6/     � Title  6	   �� *Titulo+.��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Numero��6   $��0��6!   $��0��6.   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly 6/   �� *IsReadOnlyNumero+��6W   �� *Numero+�� 5   
   $��Descripcion��6   $��1��6&   $��0��63   �� 5   
   $��1��6   $��1��6    6/   �� *IsReadOnlyDescripcion+��6\   �� *Descripcion+�� 5   
   $��CodigoProveedor��6   $��2��6*   $��0��67   �� 5   
   $��2��6   $��1��6    6/   �� *IsReadOnlyCodigoProveedor+��6`   �� *CodigoProveedor+&   System.Windows.Controls.DataGrid  5   
   $��3��6u   $��2��6�    �� SelectedItem 6   �� *SeleccionarTelefonoProveedor+��6I   �� *TelefonoProveedores+5!      �� 5"   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5#      �� $	��Add��6   $	��Add��6A   ��6#   �� *	Instancia+6A   �� 5$      $��Delete��6   �� 5%      $��Update��6   �� 5&      $
��Save��6   �� 5'      $��Cancel��6   5(      5+      5,      