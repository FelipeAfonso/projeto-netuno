   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:View.CustomControlsView.CustomControls  5   	   +    %View.CustomControls.CreateAdminDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:View.CustomControls     5   	     � Title$  Criar Administrador��5   	      NetuneDefaultBackground#���   6%    � WindowStyle$
 None=�6\   $	��335��6o   $	��400��6|    � 
ResizeMode$ NoResize=�6�    � ShowInTaskbar .   � Topmost .  � WindowStartupLocation$ CenterScreen=�6�     NetunoDefaultBorderBrush#���  6�   $��2q�6!  .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��107* �6   .+�5   
   � -   5         �Name$ FormControl��5      $��2��6$   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5       �� Angle$ 90Q�6.    �� CenterY$	 0.5Q�69    �� CenterX$	 0.5Q�6G   T� 5      5      .��5       �  � Color$ 	#FFBDDAFF��6#    � Offset$ 0Q�65   � 5!      $ 	#FFEFF6FF��6#   $ 1Q�65   5"      .+�5$      �� -   5         ��Name$ label��5$      $��Criar Administrador��6#   $��	10,0,0,10q�6A   $��36(�6j   $��Segoe WP Semibold)�6x   $
��Left=�6�   $��Bottom=�6�   ��6T   Z� 6�   �� 5%      -   5         ��Name$ buttonShutdown��5%      $��Desligar��6-   $��Right=�6@   $��0,5,5,0q�6\   $	��Top=�6m    �� IsCancel . $��10(�6�   $	��3,1q�6�   ���	#FFE23D3D���	#FFEFF6FF��6�   Z� 6�   5&      �� 5'   
   $��Nome:��6   $��Right=�6    $��	0,14,5,14q�6<   $��1��6O   $��Center=�6\   $��18(�6w   $��34��6�   $��63��6�   �� 5(   
   -   5         ��Name$ textBoxNome��5(       �� TextWrapping$
 Wrap=�6'   $��1��6;   $��1��6H   $��Center=�6X   $��	10,0,20,0q�6s   $��18(�6�   �� 5)   
   $��Email:��6   $��Right=�6!   $��	0,14,5,14q�6=   $��2��6P   $��Center=�6]   $��18(�6x   $��34��6�   $��56��6�   �� 5*   
   -   5        $ textBoxEmail��5*      $
 Wrap=�6(   $��2��6<   $��1��6I   $��	10,0,20,0q�6Y   $��18(�6l   $��Center=�6z   �� 5+   
   $��Senha:��6   $��Right=�6!   $��	0,14,5,14q�6=   $��3��6P   $��Center=�6]   $��18(�6x   $��34��6�   $��62��6�   G� 5,   
   -   5         G�Name$ textBoxPassword��5,      $��1��6/   $��	10,0,20,0q�6?   $��3��6R   $��Center=�6_   $��18(�6z   �� 5-   
   -   5        $ buttonCadastrar��5-      $��	Cadastrar��6*   $��1��6>   $��Right=�6N   $��	0,0,20,20q�6j   $��4��6}   $��Bottom=�6�    ! NetunoDefaultButtonBackground#���  6�   #���  6�   #���   6  $��18(�6R  $
��15,1q�6`  $��28��6o  $	��107��6{   �� 	IsDefault . 6�  5/      50      