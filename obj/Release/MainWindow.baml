   M S B A M L   `   `   `  ���� J  FJW media player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:thurst_media_playerthurst_media_player  K*clr-namespace:thurst_media_player.Controlsthurst_media_player.Controls  $    thurst_media_player.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:thurst_media_player     :mar*clr-namespace:thurst_media_player.Controls       � Title$  Meeting Broadcasting��$��216.165��$��338.59�� � 
ResizeMode$ CanMinimize=� � Icon$ jw_icon.ico�� � DataContext ��  �� RelativeSource ��  �� Mode$
 Self=�.���  � RowDefinitions �� $	��40* ��� $
��136* ��� $	��11* � � ColumnDefinitions �� $��0* ��� $
��101* ��� $
��188* ��� $	��42* ��� $��9* �.+��� -    ��Name$
 play��|�.     PlayButtonStyle#��[  $��Center=�$��Bottom=�
������ 	 J� RenderTransformOrigin$	 0.5,0.5&�$��0q�
 � Cursor$

 Hand�� J� IsHitTestVisible .  J� 	AllowDrop . $��54��$	��125��$	��120��$��2��$��	10,0,49,0q�$��1������  �� ImageSource$ Resources/pause-icon.png���� -    ��Name$ Duration��$��00:00:00��$
��Left=�$��Bottom=�$��45��$��Times New Roman)�$��29(�$
��Bold"�$	 -1.634,-0.643&�$	��132��$��5,0,0,86q�$��1��$��2��$��1���� -    ��Name$ volumeSlider��$��0,10,4,0q�$	��Top=�$��Right=� �� IsMoveToPointEnabled .  �� Orientation$ Vertical=�|�.  $��95��$��29��$��3��$��1�� � Value$	 0.5Q� � Maximum$ 1Q�$
��Auto=� �� TickPlacement$
 Both=��� 
���   �$��3q� �� CornerRadius$ 10��$	��0,5q�$��37��$��Right=�$��3��$��2��$��1���� -   $
 mute��|�.  
������ $��3��$��1��$��Right=�$	��Top=�$��	0,105,4,0q�$��0q�$��26��$��29��  
VolumeIcon#��[ .   (thurst_media_player.Controls.MarqueeText  -     Name$ marqueeAttention��
������ $��21(�   MarqueeTimeInSeconds$ 18Q�
���   �$��0,-1,-167,4q�$��5��/   )thurst_media_player.Controls.LoadingPanel  $��0,93,161,-2q�$��56��$��1��$��1��$��Center=�$��2��$��2��   	IsLoading �� *	IsLoading+�� -    ��Name$ title��$��JW Media Player��$��4��$	��240��$
��Left=�$��45,2,0,1q�$��29(�$
��Wrap=�$��Arial)� �� TextAlignment$ Center=��� $��5��	 �� X1$ 0��	 �� Y1$ 0��	 �� X2$	 333��	 �� Y2$ 0��
���   �$��3��