   M S B A M L   `   `   `  ����H  DWPFSlidePanel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPFSlidePanelWPFSlidePanel  5   	   F BWPFControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP7clr-namespace:WPFControls.Controls;assembly=WPFControlsWPFControls.Controls 5   	       WPFSlidePanel.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WPFSlidePanel     5   	   [ WFontAwesome6.Svg.Net, Version=2.5.1.0, Culture=neutral, PublicKeyToken=150287d219411f042fa6(http://schemas.fontawesome.com/icons/svg  5   	   Fcontrols7clr-namespace:WPFControls.Controls;assembly=WPFControls  5   	     � Title$  
MainWindow��5
   	   $	��600��6   $
��1000��6)    � 	Resources 5         BasicButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property	 P� Value��%z  &	        �� 5   
   " ��6)   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $��0q�61   #��z��6E   ._�5      �� $
��Left=�6/   $��Center=�6J   #��z��6e   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   5      5      5      5      .��5      � -   5        
 �Name$
 parent��5      .+�5    
   %  WPFControls.Controls.SlidePanel  -   5          Name$ 
slidePanel��5          SliderWidth$	 400Q�62      AnimationSpeed$	 300Q�6D      SliderLocation$
 Left=�6Y   .��5!      �� .+�5"      �� 
���   �._�5#      ��  �� Orientation$ Vertical=�6!   $��Center=�68   $��10q�6U   .+�5$      #  FontAwesome6.Svg.ImageAwesome     Icon$ Brands_Apple=�6+      PrimaryColor
 �����$	��100��6T   �� 5%      $��Cielo��6$   $��30(�61   
�������$��Center=�6R   �� 5&      $��cielo@cielo.co.kr��6$   $��30(�6=   
�������$��Center=�6^   5'      5(      �� 5)      $��설정��6   $��30(�6&   $��10q�64   �� 5*      $��고객센터��6   $��30(�6(   $��10q�66   �� 5+      $��	이벤트��6   $��30(�6'   $��10q�65   �� 5,      $��회원가입��6   $��30(�6(   $��10q�66    � Cursor$
 Hand��6d   ��6B   �� *SignupCommand+6d   5-      5.         WPFControls.Controls.Modal  50   
      ShadowColor$
 Blue��6      IsOpen 6,   �� *IsSignupModalOpen+ �� Mode$ TwoWay=�.��51      � $	��500��6   $	��500��6   .+�52      �� $ Vertical=�6   $��Center=�64   $��Stretch=�6O   $��20q�6m   .+�53      �� $��회원가입��6    $��50(�6,   
����  �$��Center=�6L   �� 54      $��ID��6    $��30(�6*   �� 55      $��30(�6   �� 56      $��Email��6    $��30(�6-   �� 57      $��30(�6   �� 58      $��Password��6    $��30(�60   G� 59      $��30(�6"   �� 5:      $��Confirm Password��6    $��30(�68   G� 5;      $��30(�6#   �� 5<      $��Submit��6   $��30(�6V   ��6.   �� *SignupSubmitCommand+6V   5=      5>      5?      � 5B   
    � RowDefinitions 5C      �� 5D      $
��Auto �6    �� 5E      $��* �6    �� 5F      $
��Auto �6    .+�5I      �� 
�����_�$��50��6,   ._�5J      �� $ 
Horizontal=�6   $��Center=�66   $��10q�6Q   .+�5K      �� -   5        
������ 
������ $
 Hand��5K   e   #��[  5L      .��5M        $ 
Solid_Bars=�6+   $��20��6=   $��20��6H   
 �����6T   5N      �� 5O      $��My App��6    
�������$��20(�6A   $
��Bold"�6O   $��10 0 0 0q�6a   5P      5Q      � 5S      $��1��6   $��20q�6     5T      �� 5U      $
��Auto �6$   �� 5V      $��* �6$   .+�5X      �� $��My Page��6   $��30(�6+   $
��Bold"�69   �� 5Z      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6`   .+�5[        $ Brands_GgCircle=�6'   $	��150��6>   $	��150��6K     5\      $ Brands_TradeFederation=�6'   $	��150��6E   $	��150��6R   $��10 0 5 0q�6^     5]      $ Solid_TriangleExclamation=�6'   $	��150��6H   $	��150��6U   $��5 0 10 0q�6a     5^      $ Solid_Diamond=�6'   $	��150��6<   $	��150��6I   5_      5`      �� 5b      $��2��6   
�����_�$��40��69   ._�5c      �� $��@2023 My Company��6   
�������$��15(�6G   $
��Bold"�6U   $��10 0 0 0q�6g   $��Center=�5d      5e      5f      5g      5h      