   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:View.SubWindowsView.SubWindows  5   	   Q MCurrencyTextBoxControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:CurrencyTextBoxControl;assembly=CurrencyTextBoxControlCurrencyTextBoxControl 5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	   ,    &View.SubWindows.AdicionarProdutoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:View.SubWindows     5   	   YcurrencyDclr-namespace:CurrencyTextBoxControl;assembly=CurrencyTextBoxControl     5   	   iControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5   	   -   5          � Title$  Cadastrar Produto��5
   	   $	��800��6#   $	��600��62      NetuneDefaultBackground#���   6B    � Icon$( "/View;component/Resources/Logo.png��6�    � 	Resources 5        AutoCompleteBoxItemTemplate �� Orientation �� ContentStringFormat��%�  &	       �� 5   
   .R�5      �� $��Right=�6   $ 
Horizontal=�65   .+�5      �� ��6   �� *Nome+�� 5      ��6   �� *Codigo+�� 5      ��6   �� *	Descricao+�� 5      $ R{0:C}��67   $��Right=�6T   ��6   �� *
PrecoVista+6T   �� 5      $y�	Collapsed=�6   $��Right=�6/   $ R{0:C}��6K   ��6h   �� *
PrecoPrazo+5      5      5      .��5      � $��0q�6    � ColumnDefinitions 5   
   �� 5      $	��180 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   .+�5(   
   � $��0q�6   $��2��6   ��5)      �� 5*       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   	 �� RelativeTransform	 5+      V� 5,      .~�5-      �� 
 �� CenterY$	
 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5.       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5/       �� Angle$ 90Q�6.    �� CenterY$	 0.5Q�69    �� CenterX$	 0.5Q�6G   T� 50      51      .��53      �  � Color$ 	#FF8ABDFF��6#    � Offset$ 0Q�65   � 54      $ 	#FFEFF6FF��6#   $ 1Q�65   55      .+�57      �� -   5         ��Name$ 
LabelTitle��57      $��Novo Produto��6(   $��	10,10,0,0q�6?   $��48(�6R   $��Segoe UI Semibold)�6`   $��70��6   58      �� 59   
   $��Código:��6   $��Right=�6"   $
��0,10q�6>   $��1��6L   $��Center=�6Y   $��18(�6t   $��34��6�   $
��Bold"�6�   �� 5:   
   $��Nome:��6   $
��0,10q�6    $��2��6.   $��Center=�6;   $��18(�6V   $��Right=�6d   $��34��6�   $
��Bold"�6�   �� 5;   
   $��Preço de Custo:��6   $
��0,10q�6*   $��3��68   $��18(�6E   $��Center=�6S   $��Right=�6n   $��34��6�   �� 5<   
   $��Preço a Vista:��6   $
��0,10q�6)   $��4��67   $��Center=�6D   $��18(�6_   $��Right=�6m   $��34��6�   $
��Bold"�6�   �� 5=   
   $��Preço a Prazo:��6   $��	0,10,0,11q�6)   $��5��6<   $��Center=�6I   $��18(�6d   $��Right=�6r   $��34��6�   �� 5>   
   $��
Categoria:��6   $
��0,10q�6%   $��6��63   $��Center=�6@   $��18(�6[   $��Right=�6i   $��34��6�   �� 5?   
   $��Estoque Inicial:��6   $��	0,11,0,10q�6+   $��7��6>   $��Center=�6K   $��18(�6f   $��Right=�6t   $��34��6�   �� 5@   
   $��Descrição:��6   $
��0,10q�6%   $��8��63   $��Center=�6@   $��18(�6[   $��Right=�6i   $��34��6�   �� 5A   
   $��Fornecedor:��6   $��	0,10,0,11q�6&   $��9��69   $��Center=�6F   $��18(�6a   $��Right=�6o   $��34��6�   � 5B   
   -   5         �Name$ FormGrid��5B      $��9��6!   $��1��62   $��1��6?    5C      �� 5D      $��* �6#   �� 5E      $��* �6#   �� 5F      $��* �6#    5H      �� 5I      $��* �6    �� 5J      $��* �6    �� 5K      $��* �6    �� 5L      $��* �6    �� 5M      $��* �6    �� 5N      $��* �6    �� 5O      $��* �6    �� 5P      $��* �6    �� 5Q      $��* �6    .+�5S      �� -   5         ��Name$ textBoxCodigo��5S      $��10,0,5,0q�6Q    �� TextWrapping$
 Wrap=�6c   $��Center=�6w   $��18(�6�   $��2q�6�   $��30��6�   �� 5T      -   5        $ textBoxNome��5T      $��10,0,5,0q�6+   $
 Wrap=�6=   $��Center=�6Q   $��18(�6l   $��2q�6z   $��30��6�   $��1��6�   $��2��6�   ,  &CurrencyTextBoxControl.CurrencyTextBox  5U      -   5          Name$ textBoxPrecoCusto��5U   '   $��10,0,5,0q�6B   $
 Wrap=�6T   $��Center=�6h   $��18(�6�   $��2q�6�   $��30��6�   $��2��6�   $��R$0.00��6�      MaximumValue$ 99999999999999999~�6�     5V      -   5        $ textBoxPrecoVista��5V   '   $��10,0,5,0q�6B   $
 Wrap=�6T   $��Center=�6h   $��18(�6�   $��2q�6�   $��30��6�   $��3��6�   $��R$0.00��6�   $ 99999999999999999~�6�     5W      -   5        $ textBoxPrecoPrazo��5W   '   $��10,0,5,0q�6B   $
 Wrap=�6T   $��Center=�6h   $��18(�6�   $��2q�6�   $��30��6�   $��4��6�   $��R$0.00��6�   $ 99999999999999999~�6�   {�.  6�   �� 5X      -	   5        $ textBoxEstoque��5X      $��10,0,5,0q�6R   $
 Wrap=�6d   $��Center=�6x   $��18(�6�   $��2q�6�   $��30��6�   $��6��6�   $��0��6�    �� 	IsEnabled . 6�   �� 5Y      -
   5        $ textBoxDescricao��5Y      $��10,0,5,0q�60   $
 Wrap=�6B   $��Center=�6V   $��18(�6q   $��2q�6   $��30��6�   $��7��6�   $��2��6�   �� 5Z      -   5         ��Name$ checkBoxEstoque��5Z      $��Controlar Estoque��60   $��1��6L   $
��Left=�6\   $��10,0,0,0q�6w   $��6��6�   $��Center=�6�    d� 	IsChecked$
 TrueY�6�   6�   �� 5[      -   5         ��Name$ comboBoxFornecedores��5[      $��10,0,5,0q�65   $��8��6G   $��Center=�6T   $��18(�6o   $��2��6}   �� 5\      -   5        $ checkBoxPreco��5\      $��Dois Preços��6.   $��1��6D   $
��Left=�6T   $��	10,16,0,0q�6o   $��3��6�   $	��Top=�6�   6�   -  'System.Windows.Controls.AutoCompleteBox  5]      -   5          Name$ AutoCompleteBoxCategoria��5]   '   $��18(�6I   $��Segoe UI Semibold)�6W   $��1q�6v   $��10,0,5,0q�6�   $��Center=�6�   $��Center=�6�      ItemTemplate# [ 6�      ValueMemberPath$
 Nome��6  $��1��6,  $��2��69  $��5��6M  ���	#FFABADB36Z  �� 5^      -   5        $ checkBoxOnline��5^      $ ��Produto Disponível Online��6/   $��2��6S   $
��Left=�6c   $��
10,14,0,14q�6~   $��7��6�   $��Center=�6�   $
 TrueY�6�   6�   5_      �� 5`   
   -   5          ��Name$  	buttonAdd��5`      $��	Adicionar��6$   $��Right=�68   $��	0,0,25,20q�6T   $��10��6g   $��Bottom=�6u    ! NetunoDefaultButtonBackground#���  6�     NetunoDefaultBorderBrush#���  6�   #���   6  $��18(�6=  $
��15,1q�6K  ! �� 	IsDefault! . $��1��6�  �� 5a   
   -   5        $  buttonLimpar��5a      $��Limpar��6'   $��Right=�68   $��
0,0,140,20q�6T   $��10��6h   $��Bottom=�6v   ���	#FF71A8EA#���  6�   #���   6�   $��18(�6  $
��15,1q�6&  $��1��65  " �� IsCancel" . 6U  5c      5d      