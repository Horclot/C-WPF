   M S B A M L   `   `   `  ����N  JPage Navigation App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel  5      '    !Page_Navigation_App.View.Products   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :vm+clr-namespace:Page_Navigation_App.ViewModel     5         
Page_Style#��[  5
        � 	Resources  5        BuyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	       �� 5   
   " ��6'   .�5      ��  � ��$	 120��6&   �� 5       � ��$ 35��6'   �� 5       � �� �	#FF272B2F6+   �� 5       � �� �	#FF0BCDFF6,   �� 5       � �� �	#FF0BCDFF6+   �� 5       � ��$ 1q�60   �� 5       � ��$	 Buy��6(   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Arial)�6+   �� 5       � ��$ 10q�6(   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   $ 10��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5      5       5"      5#      5$       � DataContext 5&      -  'Page_Navigation_App.ViewModel.ProductVM  5'   
   .��5*      � $��15q�6   .+�5+   
   �� $��0,67,0,0q�67   ��6   �� *	Product+��5,      �� 5-      .R�5.      �  � Orientation$ 
Horizontal=�6    5/      ��51      �� 52      .R�53      �� $��	20,0,20,5q�6   ._�54      �� .+�55      �� $	��150��6A   $	��150��6M   ��6$   �� *	ImagePath+6M   �� 56      $��Center=�6>   ���	#FF0BCDFF$
��22px(�6r   $��Rubik)�6�   ��6(   �� *Name+6�   �� 57      $��Center=�6Y   ���	#FF0BCDFF$
��18px(�6�   $��Rubik)�6�   ��6(   �� *Price+ �� StringFormat$ ${0:F2}��6�   �� 58      -   5        #��[ 58   %   
	 � Tag	 6e   �� 59      5:      5;      5=      �� 5>   
   $
��Left=�6   $��
268,24,0,0q�6+   $	��Top=�6?   �� 5?   
   $&�� Add options for your application��6   $��Center=�6;   $��0,10,0,0q�6X   $	��Top=�6j   ���	#FF0BCDFF$��24(�6�   5@      5A      