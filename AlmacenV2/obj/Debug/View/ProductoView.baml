   M S B A M L   `   `   `  ����D  @AlmacenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AlmacenV2.ViewAlmacenV2.View  5   	   !    AlmacenV2.View.ProductoView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AlmacenV2.View     5   	   $	��800��5   "   $	��600��6/     � Title  6	   �� *Titulo+.��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��CodigoCategoria��6   $��0��6*   $��0��67   �� 5   
   $��1��6   $��1��6    �� 
IsReadOnly 6/   �� *IsReadOnlyCodigoCategoria+��6`   �� *CodigoCategoria+�� 5   
   $��CodigoEmpaque��6   $��1��6(   $��0��65   �� 5   
   $��1��6   $��1��6    6/   �� *IsReadOnlyCodigoEmpaque+��6^   �� *CodigoEmpaque+�� 5   
   $��Descripcion��6   $��2��6&   $��0��63   �� 5   
   $��1��6   $��1��6    6/   �� *IsReadOnlyDescripcion+��6\   �� *Descripcion+�� 5    
   $��PrecioUnitario��6   $��3��6)   $��0��66   �� 5!   
   $��1��6   $��1��6    6/   �� *IsReadOnlyPrecioUnitario+��6_   �� *PrecioUnitario+�� 5"   
   $��PrecioPorDocena��6   $��4��6*   $��0��67   �� 5#   
   $��1��6   $��1��6    6/   �� *IsReadOnlyPrecioPorDocena+��6`   �� *PrecioPorDocena+�� 5$   
   $��PrecioPorMayor��6   $��5��6)   $��0��66   �� 5%   
   $��1��6   $��1��6    6/   �� *IsReadOnlyPrecioPorMayor+��6_   �� *PrecioPorMayor+�� 5&   
   $��
Existencia��6   $��6��6%   $��0��62   �� 5'   
   $��1��6   $��1��6    6/   �� *IsReadOnlyExistencia+��6[   �� *
Existencia+�� 5(   
   $��Imagen��6   $��7��6!   $��0��6.   �� 5)   
   $��1��6   $��1��6    6/   �� *IsReadOnlyImagen+��6W   �� *Imagen+&   System.Windows.Controls.DataGrid  5+   
   $��8��6b   $��2��6o    �� SelectedItem 6   �� *SeleccionarProducto+��6@   �� *	Productos+5-      �� 5.   
   $��9��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5/      �� $	��Add��6   $	��Add��6A   ��6#   �� *	Instancia+6A   �� 50      $��Delete��6   �� 51      $��Update��6   �� 52      $
��Save��6   �� 53      $��Cancel��6   54      56      57      