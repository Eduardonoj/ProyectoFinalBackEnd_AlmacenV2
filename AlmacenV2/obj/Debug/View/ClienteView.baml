   M S B A M L   `   `   `  ����D  @AlmacenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AlmacenV2.ViewAlmacenV2.View  5   	        AlmacenV2.View.ClienteView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AlmacenV2.View     5   	   $	��450��5   "   $	��800��6/     � Title  6	   �� *Titulo+.��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $	��Dpi��6   $��0��6   $��0��6+   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly 6/   �� *IsReadOnlyDpi+��6T   �� *Dpi+�� 5   
   $��Nombre��6   $��1��6!   $��0��6.   �� 5   
   $��1��6   $��1��6    6/   �� *IsReadOnlyNombre+��6W   �� *Nombre+�� 5   
   $��	Direccion��6   $��2��6$   $��0��61   �� 5   
   $��2��6   $��1��6    6/   �� *IsReadOnlyDireccion+��6Z   �� *	Direccion+&   System.Windows.Controls.DataGrid  5   
   $��3��6`   $��2��6m    �� SelectedItem 6   �� *SeleccionarCliente+��6?   �� *
Clientes+5      �� 5   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5       �� $	��Add��6   $	��Add��6A   ��6#   �� *	Instancia+6A   �� 5!      $��Delete��6   �� 5"      $��Update��6   �� 5#      $
��Save��6   �� 5$      $��Cancel��6   5%      5&      5'      