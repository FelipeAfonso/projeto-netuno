   M S B A M L   `   `   `  ����Q  MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete  5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	    View   View.PontoVendaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      \	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   iControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6B   -   5          � Title$  Ponto de Venda��5   	   $	��600��6    $	��800��6-   $	��800��69   $	��600��6H    � WindowState$ 	Maximized=�6X    � Icon$( "/View;component/Resources/Logo.png��6�   ��5	      
� 5
   
    
� RadiusY$
 1.29Q�6    
� RadiusX$ 1.124Q�6-    
� Center$ 0,-0.015&�6=    
� GradientOrigin$ -0.119,-0.135&�6O   .��5      �  � Color$ 	#FFD7E9FB��6    � Offset$ 1Q�6-   � 5      $ White��6   $ 0.145Q�6)   5      	 � 	Resources	 5         AutoCompleteBoxItemTemplate
 �� Orientation �� ContentStringFormat��%�  &	        �� 5   
   .R�5      �� $
 
Horizontal=�6   $��Right=�62   .+�5      �� ��6   �� *Nome+�� 5      ��6   �� *Codigo+�� 5      ��6   �� *	Descricao+�� 5      $ R{0:C}��67   $��Right=�6T   ��6   �� *
PrecoVista+6T   �� 5      $ R{0:C}��67   $��Right=�6T   $y�	Collapsed=�6p   ��6   �� *
PrecoPrazo+6p   5      5      5      .��5      ]� -   5         ]�Name$ PVDock��5      $��15q�6    .+�5   
   ]� -   5        $ dockTop��5      $	��Top=�6%   $	��150��6:   $��-15,-15,-15,15q�6J   $	��100��6b   .+�5      �� $
��Left=�6   $	��Top=�6/   $(��"/View;component/Resources/Logo.png��6G   $��	15,15,0,0q�6s   � 5      $��Right=�6   $	��150��6/   $��Right=�6<    � RowDefinitions 5      �� 5      �� 5       $��2* �6$    � ColumnDefinitions 5"      �� 5#      $	��100 �6'   �� 5$      $��* �6'   .+�5&      �� $��
Operador: ��6   $��Right=�6-   $��Center=�6I   �� 5'      -   5         ��Name$ 	labelName��5'      $��Teste da Silva Souza��6+   $��1��6J   $��Center=�6Z   $��0q�6w   $��Center=�6�   $��Center=�6�   �� 5(      -   5         ��Name$ buttonSalvar��5(      $��Salvar��6/   $��	15,5,15,0q�6@    ! NetunoDefaultButtonBackground#���  6S     NetuneDefaultBackground#���  6�     NetunoDefaultBorderBrush#���  6�   $��18(�6   $
��Bold"�6  $��2��6   $��1��64  $��4��6\  $	��Top=�6i  $��55��6�  �� 5)      -   5        $ buttonLimpar��5)      $��Limpar��6/   $��	15,0,15,5q�6@   ���	#FFF04545#���  6j   #���  6�   $��18(�6�   $
��Bold"�6�   $��2��6�   $��1��6  $��4��66  $��30��6C  $��Bottom=�6O  5*      � 5+      $	��Top=�6   .+�5,      �� $
��Wrap=�6   $��Ponto de Venda��60   $��Segoe UI Semibold)�6F   $��36(�6e    �� TextAlignment$ Center=�6s   $��Center=�6�   5-      5.      ]� 5/   
   -   5        $ 
gridBottom��5/      $��Bottom=�6(   $	��100��6@   $	��100��6P   $��Bottom=�6`   .+�50      � $��Right=�6    � UseLayoutRounding . #���  6H    51      �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   .+�57      �� $��Forma de Pagamento��6   $��Center=�65   	� 58      -   5         	�Name$ RadioButtonDinheiro��58      $��Dinheiro��6;   $��5,5,0,5q�6N   $��1��6_    	� 	GroupName$ FormaPagamento��6l    d� 	IsChecked$
 TrueY�6�   6�   	� 59      -	   5        $ RadioButtonCartao��59      $��Cartão��69   $
��Left=�6J   $	��Top=�6e   $��16��6}   $��2��6�   $��5,5,0,5q�6�   $ FormaPagamento��6�   	� 5:      -
   5        $ RadioButtonCheque��5:      $��Cheque��69   $
��Left=�6J   $	��Top=�6e   $��16��6}   $��3��6�   $��5,5,0,5q�6�   $ FormaPagamento��6�   5;      � 5<      $��Right=�6    . #���  6H   $��0,0,5,0q�6    5=      �� 5>      $��* �6$   �� 5?      $��* �6$   .+�5A      	� -   5        $ RadioButtonVista��5A      $��A Vista��68   $��0,0,0,5q�6J   $ 	Pagamento��6[   $
 TrueY�6q   $��Bottom=�6�   {�.  6�   	� 5B      -   5        $ RadioButtonPrazo��5B      $��A Prazo��68   $��0,5,15,0q�6J   $ 	Pagamento��6\   $��1��6r   {�.  6�   5C      � 5D      -   5         �Name$ 	GridInput��5D      $��Right=�6&   $��10,0,0,0q�6=    +� FocusedElement 6O   ��  �� ElementName$ AutoCompleteBoxBusca�� 5E      �� 5F      �� 5G      $	��120 �6'   �� 5H      $	��120 �6'   .+�5J      �� -   5         ��Name$ 	textBlock��5J      $
��Left=�6/   $��0,0,0,64q�6J   $
��Wrap=�6\   $��Código ou Nome��6p   $��Center=�6�   $��16(�6�   $
��Bold"�6�   -  'System.Windows.Controls.AutoCompleteBox  5K      -   5          Name$ AutoCompleteBoxBusca��5K   +   $��18(�6I   $��Segoe UI Semibold)�6W   $��3,2,2,2q�6v   $��0,0,15,0q�6�   $��Center=�6�   $��40��6�   $��Center=�6�   #���  6�      ItemTemplate# [  6K     ValueMemberPath$
 Nome��6�  $��1��6�  �� 5L      -   5         ��Name$ textBoxQuantidade��5L      $��1��65   $��40��6E   $��0q�6Q    �� TextWrapping$
 Wrap=�6\   $��Center=�6p   $��18(�6�   $��2q�6�   $��Center=�6�   #���  6�   $��2q�6   $��2��6\  �� 5M      -   5        $ label��5M      $��
Quantidade��6'   $��1��6<   $
��Left=�6L   $��0,0,0,64q�6g   $��Center=�6y   $��16(�6�   $
��Bold"�6�   $��0q�6�   �� 5N      -   5        $ buttonAdicionar��5N      $��	Adicionar��62   $��2��6F   $��15,15,15,46q�6V   #���  6k   #���  6�   #���  6�   $��18(�6  $
��Bold"�6&  $��3��6V  �� 5O      -   5        $ buttonRemover��5O      $��Remover��60   $��2��6B   $��15q�6R   ���	#FFF04545#���  6u   #���  6�   $��18(�6�   $
��Bold"�6�   $��30��6  $��Bottom=�6  6,  5P      5Q      � 5R   
   -   5        $ 	gridDados��5R      $��Right=�6"   $��10,0,0,0q�69   $	��176��6K   $	��200��6W   $	��350��6f    5S      �� 5T      $��37 �6    �� 5U      $��* �6    �� 5V      $��* �6    �� 5W      $��* �6    �� 5X      $��* �6     5Z      �� 5[      $��* �6#   �� 5\      $��* �6#   �� 5]      $��* �6#   �� 5^      $��* �6#   .+�5`      �� $��Itens��6   $��Right=�6$   $	��Top=�6@   $��26��6X   $��35��6d   �� 5a      $��Volumes��6   $	��Top=�6&   $��0q�6>   $��2��6I   $��Right=�6Y   $��26��6u    J� IsHitTestVisible . 6�   �� 5b      -   5        $ 
labelItens��5b      $��0��6(   $
��Left=�64   $��0q�6O   $	��Top=�6Z   $��1��6r   #���  6�   $��26��6�   $��16��6�   �� 5c      -   5        $ labelVolumes��5c      $��0��6*   $
��Left=�66   $	��Top=�6Q   $��3��6i   #���  6y   $��26��6�   $��16��6�   � 5d      $��4��6   $��1��6'   $	��0,5q�64   .+�5e      �� ���	#FFE9F3FF#���  6-   $��0q�6a     �� RadiusX$  5��6l   ! �� RadiusY$! 5��6x   �� 5f      $��5q�6   $
��Wrap=�6'   $��Valor Total��6;   $��Center=�6N   $
��Left=�6i   $	��100��6�   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5g      -   5        $ textBlockValorTotal��5g      $��5q�69   $
��Wrap=�6D   $��R$ 0.0��6X   $��Right=�6f   $��Segoe UI Semibold)�6�   $��20(�6�   $��Center=�6�   5h      � 5i      $��4��6   $��2��6'   $	��0,5q�64   .+�5j      �� #���  6   #���  6M   $��0q�6�   $  5��6�   $! 5��6�   �� 5k      $��5q�6   $
��Wrap=�6'   $��Parcelas��6;   $��Center=�6K   $
��Left=�6f   $	��100��6�   $��Segoe UI Semibold)�6�   $��16(�6�   �� 5l      -   5        $ textBlockParcelas��5l      $��5q�67   $
��Wrap=�6B   $��1x��6V   $��Right=�6`   $��Segoe UI Semibold)�6|   $��16(�6�   $��Center=�6�   5m      � 5n      $��4��6   $��3��6'   $	��0,5q�64   .+�5o      �� #���  6   #���  6M   $��0q�6�   $  5��6�   $! 5��6�   �� 5p      $��5q�6   $
��Wrap=�6'   $��Valor da Parcela��6;   $��Center=�6S   $
��Left=�6n   $	��100��6�   $��Segoe UI Semibold)�6�   $��16(�6�   �� 5q      -   5        $ textBlockValorParcela��5q      $��5q�6;   $
��Wrap=�6F   $��R$ 0,00��6Z   $��Right=�6i   $��Segoe UI Semibold)�6�   $��16(�6�   $��Center=�6�   5r      � 5s      $��4��6   $��4��6'   $	��0,5q�64   .+�5t      �� #���  6   #���  6M   $��0q�6�   $  5��6�   $! 5��6�   �� 5u      $��5q�6   $
��Wrap=�6'   $��Desconto��6;   $��Center=�6K   $
��Left=�6f   $	��100��6�   $��Segoe UI Semibold)�6�   $��16(�6�   �� 5v      -   5        $ textBlockValorTotal3��5v      $��5q�6:   $
��Wrap=�6E   $��R$ 0,00��6Y   $��Right=�6h   $��Segoe UI Semibold)�6�   $��16(�6�   $��Center=�6�   5w      5x      &   System.Windows.Controls.DataGrid  5y   
   -   5        "  Name$" dataGridProdutos��5y      $��0,0,0,5q�6-   $��0q�6>   
�������$# �� IsSynchronizedWithCurrentItem$
# TrueY�6]   $   AutoGenerateColumns$ .  %   GridLinesVisibility$% 
Horizontal=�6�   $��18(�6�   &   Columns& 5z      0  *System.Windows.Controls.DataGridTextColumn  5{      ,  &System.Windows.Controls.DataGridColumn'   Header$' Código��6g   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 6%   �� *
Key.Codigo+)   ClipboardContentBinding) 6D   Z� 6g     5|      $
' Nome��6e   ( 6%   �� *
Key.Nome+) 6B   Z� 6e     5}      -   5        DataGridColumnVista��$' Preço a Vista��5}   �   ( 6B   �� *Key.PrecoVista+* �� StringFormat$* R{0:C}��) 6|   Z� 6�     5~      -   5        DataGridColumPrazo��$' Preço a Prazo��5~   �   +   
Visibility$+ 	Collapsed=�6�   ( 6A   �� *Key.PrecoPrazo+$* R{0:C}��) 6{   Z� 6�     5      $' 
Quantidade��6b   ( 6%   �� *Value+) 6?   Z� 6b   5�      5�      5�      