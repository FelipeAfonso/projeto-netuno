   M S B A M L   `   `   `  ����  View'    !View.CustomControls.EstoqueDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  EstoqueDialog��5   	   $	��400��6   $	��300��6.   $	��400��6>   $	��300��6J    � WindowStyle$
 None=�6W    � 
ResizeMode$ NoResize=�6j   .��5      � $��0q�6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��2* �6   �� 5	      $��2* �6   �� 5
       � ColumnDefinitions 5   
   �� 5      $	��116 �6   �� 5      .+�5   
   � -   5         �Name$ FormControl��5      $��2��6$   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      �� 	 �� CenterY$		 0.5Q�6-   
 �� CenterX$	
 0.5Q�6;   �� 5       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5       �� Angle$ 90Q�6.    �� CenterY$	 0.5Q�69    �� CenterX$	 0.5Q�6G   T� 5      5      .��5      �  � Color$ 	#FFBDDAFF��6#    � Offset$ 0Q�65   � 5      $ 	#FFEFF6FF��6#   $ 1Q�65   5      .+�5      �� -   5         ��Name$ labelTitulo��5      $��Estoque��6)   $��	10,0,0,10q�6;   $��36(�6d   $��Segoe WP Semibold)�6r   $
��Left=�6�   $��Bottom=�6�   ��6N   Z� 6�   5       �� 5!   
   $��Produto:��6   $��Right=�6#   $��0,0,5,0q�6?   $��1��6P   $��Center=�6]   $��18(�6x   �� 5"   
   $��Quantidade:��6   $��Right=�6&   $��0,0,5,0q�6B   $��2��6S   $��Center=�6`   $��18(�6{   $��34��6�   �� 5#   
   -   5         ��Name$ textBoxQuantidade��5#       �� TextWrapping$
 Wrap=�6-   $��2��6A   $��1��6N   $��	10,0,20,0q�6^   $��18(�6q   $��Center=�6   $��29��6�   �� 5$   
   -   5         ��Name$ buttonLancar��5$      $��Lançar��6'   $��1��68   $��Right=�6H   $��0,0,20,0q�6d   $��3��6v   $��Center=�6�    !  NetunoDefaultButtonBackground#���   6�     NetunoDefaultBorderBrush#���  6�     NetuneDefaultBackground#���  6  $��18(�6K  $
��15,1q�6Y  $��28��6h  $	��107��6t   �� 	IsDefault . $��2��6�  6�  �� 5%   
   -   5        $ buttonCancelar��5%      $��Cancelar��6)   $
��Left=�6<   $��20,5,0,5q�6W   $��3��6i   $��Center=�6v   #���   6�   #���  6�   #���  6  $��18(�6>  $
��15,1q�6L  $��28��6[  $	��107��6g   . $��2��6�  6�  �� 5&   
   -   5         ��Name$ ComboBoxProduto��5&      $��1��6,   $��	10,0,20,0q�6<   $��1��6O   $��Center=�6\   
�������$��0q�6�   ���	#FFCDCDCD6�   5(      5)      