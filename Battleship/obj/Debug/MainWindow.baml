   M S B A M L   `   `   `  ����E  ABattleship, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Battleship
Battleship  5   	       Battleship.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Battleship     5   	     � Title$  
Battleship��5   	   $	��745��6   $
��1260��6)   $��Tempus Sans ITC)�66   $��16(�6S   ���	#FF3C2709 � Icon$ icon.ico��5	   	    � 
ResizeMode$ CanMinimize=�6   .��5
      �� $��Hidden=�6   $��Hidden=�68   .��5   
   � $
��Left=�6   $
��1252��6*   $	��744��67   $	��Top=�6D    J� RenderTransformOrigin$ 0.505,0.246&�6\   
���   � � ColumnDefinitions 5      �� 5      $
��449* �6#   �� 5      $
��685* �6#   .+�5      � 
���   �6   � 5      -   5         �Name$ 
gridPlayer��5      $
��Left=�6'   $	��300��6B   $��	40,55,0,0q�6O   $	��Top=�6b   $	��300��6z   ���	#FF54B49E$��1��6�   .+�5      �� 
���   �$��2q�6-   $��10��6A   �� 5      
���   �$��2q�6-   $��10��6A   $��2��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��3��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��4��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��5��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��6��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��7��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��8��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��9��6V   �� 5      
���   �$��2q�6-   $��10��6A   $��10��6V   �� 5      
���   �$��2q�6-   $��11��6B   �� 5      
���   �$��2q�6-   $��11��6B   $��2��6T   �� 5       
���   �$��2q�6-   $��11��6B   $��3��6T   �� 5!      
���   �$��2q�6-   $��11��6B   $��4��6T   �� 5"      
���   �$��2q�6-   $��11��6B   $��5��6T   �� 5#      
���   �$��2q�6-   $��11��6B   $��6��6T   �� 5$      
���   �$��2q�6-   $��11��6B   $��7��6T   �� 5%      
���   �$��2q�6-   $��11��6B   $��8��6T   �� 5&      
���   �$��2q�6-   $��11��6B   $��9��6T   �� 5'      -   5         ��Name$ grid1��5'      
���   �$��2q�6<   $��10��6Q   $��10��6c    � RowDefinitions 5(      �� 5)      $	��16* �6$   �� 5*      $	��16* �6$   �� 5+      $	��16* �6$   �� 5,      $	��16* �6$   �� 5-      $	��16* �6$   �� 5.      $	��16* �6$   �� 5/      $	��16* �6$   �� 50      $	��16* �6$   �� 51      $	��16* �6$   �� 52      $	��16* �6$    55      �� 56      $	��16* �6'   �� 57      $	��16* �6'   �� 58      $	��16* �6'   �� 59      $	��16* �6'   �� 5:      $	��16* �6'   �� 5;      $	��16* �6'   �� 5<      $	��16* �6'   �� 5=      $	��16* �6'   �� 5>      $	��16* �6'   �� 5?      $	��16* �6'   5B      � 5C      -   5        $ gridComputer��5C      $
��Left=�6)   $	��300��6D   $��
400,55,0,0q�6Q   $	��Top=�6e   $	��300��6}   ���	#FF09745C$��1��6�   .+�5D      �� 
���   �$��2q�6-   $��10��6A   �� 5E      
���   �$��2q�6-   $��10��6A   $��2��6V   �� 5F      
���   �$��2q�6-   $��10��6A   $��3��6V   �� 5G      
���   �$��2q�6-   $��10��6A   $��4��6V   �� 5H      
���   �$��2q�6-   $��10��6A   $��5��6V   �� 5I      
���   �$��2q�6-   $��10��6A   $��6��6V   �� 5J      
���   �$��2q�6-   $��10��6A   $��7��6V   �� 5K      
���   �$��2q�6-   $��10��6A   $��8��6V   �� 5L      
���   �$��2q�6-   $��10��6A   $��9��6V   �� 5M      
���   �$��2q�6-   $��10��6A   $��10��6V   �� 5N      
���   �$��2q�6-   $��10��6B   �� 5O      
���   �$��2q�6-   $��10��6B   $��2��6T   �� 5P      
���   �$��2q�6-   $��10��6B   $��3��6T   �� 5Q      
���   �$��2q�6-   $��10��6B   $��4��6T   �� 5R      
���   �$��2q�6-   $��10��6B   $��5��6T   �� 5S      
���   �$��2q�6-   $��10��6B   $��6��6T   �� 5T      
���   �$��2q�6-   $��10��6B   $��7��6T   �� 5U      
���   �$��2q�6-   $��10��6B   $��8��6T   �� 5V      
���   �$��2q�6-   $��10��6B   $��9��6T   �� 5W      -   5        $ grid3��5W      
���   �$��2q�6<   $��10��6Q   $��9��6c    5Y      �� 5Z      $	��16* �6$   �� 5[      $	��16* �6$   �� 5\      $	��16* �6$   �� 5]      $	��16* �6$   �� 5^      $	��16* �6$   �� 5_      $	��16* �6$   �� 5`      $	��16* �6$   �� 5a      $	��16* �6$   �� 5b      $	��16* �6$   �� 5c      $	��16* �6$    5f      �� 5g      $	��16* �6'   �� 5h      $	��16* �6'   �� 5i      $	��16* �6'   �� 5j      $	��16* �6'   �� 5k      $	��16* �6'   �� 5l      $	��16* �6'   �� 5m      $	��16* �6'   �� 5n      $	��16* �6'   �� 5o      $	��16* �6'   �� 5p      $	��16* �6'   5s      �� 5t      -   5         ��Name$ btnStart��5t      $��START��6'   $
��Left=�67   $��117,435,0,0q�6R   $	��Top=�6g   $	��152��6   $��51��6�   $��1��6�   {�. $��26(�6�   ���	#FFE4B20A���	#FF2B2614���	#FF2B281C$��1q�6#  $��SemiBold"�67  |�.  6M  �� 5u      -   5        	 ��Name$	 lblPlayerName��5u      $��Enter your name:��6+   $
��Left=�6F   $��	10,29,0,0q�6a   $	��Top=�6t   $��39��6�   $	��179��6�   $��22(�6�   ���	#FFFFC500$��	ExtraBold"�6�   �� 5v      -   5        
 ��Name$
 txtPlayerName��5v      $
��Left=�6-   $��39��6H   $��
199,29,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��152��6�   $��20(�6�   $ 	0.475,1.5&�6�   ���	#FFF9F9F9$��SemiBold"�6�   $��Center=�6�   ���	#FF09745C$��2q�67   �� SelectionBrush �	#FF54B49E���	#FF09745C6f  �� 5w      -   5        $	 lblYourShips��5w      $��	Ship Yard��6*   $
��Left=�6>   $��
10,158,0,0q�6Y   $	��Top=�6m   $	��126��6�   $��24(�6�   ���	#FFFFC500$
��Bold"�6�   �� 5x      -	   5         ��Name$ image3��5x      $
��Left=�6$   $	��100��6?   $��
10,461,0,0q�6L   $	��Top=�6`   $	��100��6x   �� 5y      -
   5        $ btnAircarftCarrier��5y      $��10,204,289,495q�61   ���	#FFFFF5F5���	#FF0A0A0A��5z      �� 5{      .R�5|      �� $��aircraft1.png��6    5}      5      �� 5�      -   5        $ btnBattleship��5�      $ 	-0.24,1.6&�6,   $��10,277,289,399q�6N   ��5�      �� 5�      .R�5�      �� $��battleshippic1.gif��6    5�      5�      �� 5�      -   5        $ btnSubmarine��5�      $��31,396,307,308q�6+   ��5�      �� 5�      .R�5�      �� $��submarine1.png��6    5�      5�      �� 5�      -   5        $ 
btnCruiser��5�      $��21,496,289,194q�6)   ��5�      �� 5�      .R�5�      �� $��cruiserShip1.gif��6    5�      5�      �� 5�      -   5        $ btnDestroyer��5�      $��44,588,349,108q�6+   ���	#FFD61E1E���	#FFE2E2E2��5�      �� 5�      .R�5�      �� $��destroyershippic1.gif��6    5�      5�      �� 5�      -   5        $	 lblCol��5�      $
��Col:��6J   $
��Left=�6Y   $��227,221,0,0q�6t   $	��Top=�6�   $��31��6�   $��38��6�   ���	#FFE4B20A$ 0.606,0.452&�6�   $
��Bold"�6�   $y�Hidden=�6   �� Target 6$   ��  �� ElementName$ txtCol��6  �� 5�      -   5        $
 txtCol��5�      $
��Left=�6&   $��23��6A   $��283,226,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $��50��6�   
����������	#FF2B281C$��18(�6�   $��Center=�6�   $y�Hidden=�6�   �� 5�      -   5        $	 lblRow��5�      $
��Row:��6J   $
��Left=�6Y   $��227,195,0,0q�6t   $	��Top=�6�   $ -0.789,0.712&�6�   ���	#FFE4B20A$
��Bold"�6�   $��26��6�   $y�Hidden=�6�    6$   �� $ txtRow��6�   �� 5�      -   5        $
 txtRow��5�      $
��Left=�6&   $��26��6A   $��283,195,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $��50��6�   ���	#FFF7FFFD���	#FF2B281C$��18(�6�   $y�Hidden=�6�   �� 5�      -   5        $ btnOK��5�      $��OK��6$   $
��Left=�61   $��356,202,0,0q�6L   $	��Top=�6a   $��40��6y   $��34��6�   $ 
0.5,-0.294&�6�   ���	#FF54B49E$y�Hidden=�6�   	� 5�      -   5         	�Name$ radioButtonVertical��5�      $��Vertical��67   $
��Left=�6J   $��265,269,0,0q�6e   $	��Top=�6z   $y�Hidden=�6�   $��14(�6�   ���	#FFE4B20A$��Medium"�6�   	� 5�      -   5        $ radioButtonHorizontal��5�      $��
Horizontal��69   $
��Left=�6N   $��265,251,0,0q�6i   $	��Top=�6~   $��14(�6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   �� 5�      -   5        $
 txtBoxHorizontalLabels��5�      $��1��66   $
��Left=�6F   $��23��6a   $��	40,33,0,0q�6m   $
 Wrap=�6�   $I��C  1  |   2  |   3  |  4   |  5   |  6   |   7  |   8   |   9  |  10��6�   $	��Top=�6�   $	��300��6�   $��14.667(�6  $
��Bold"�6   �� 
IsReadOnly . ���	#FFBFF1E669  �� 5�      -   5        $
 txtBoxHorizontalLabels2��5�      $��1��67   $
��Left=�6G   $��23��6b   $��
400,33,0,0q�6n   $
 Wrap=�6�   $H��B  1  |  2  |  3   |  4   |  5   |  6   |  7   |  8   |   9   |  10��6�   $	��Top=�6�   $	��299��6�   $��14.667(�6  $
��Bold"�6   . ���	#FFBFF1E66:  �� 5�      -   5        $
 txtBoxVerticalLabeling1��5�      $
��Left=�67   $��30��6R   $��	11,55,0,0q�6^   $
 Wrap=�6q   $�� A��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $ -0.31,0.433&�6�   $��1��6  ���	#FFBFF1E66  �� 5�      -   5        $
 txtBoxVerticalLabeling2��5�      $
��Left=�67   $��28��6R   $��	11,85,0,0q�6^   $
 Wrap=�6q   $�� B��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $��1��6�   $ 	0.724,0.5&�6�   ���	#FFBFF1E66  �� 5�      -   5        $
 txtBoxVerticalLabeling3��5�      $
��Left=�67   $��31��6R   $��
11,113,0,0q�6^   $
 Wrap=�6r   $�� C��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $ 0.069,0.419&�6�   $��1��6  ���	#FFBFF1E66  �� 5�      -   5        $
 txtBoxVerticalLabeling4��5�      $��31��67   $��11,143,716,0q�6C   $
 Wrap=�6Y   $�� D��6m   $	��Top=�6w   $��14.667(�6�   $
��Bold"�6�    . $��1��6�   ���	#FFBFF1E66�   �� 5�      -   5        $
 txtBoxVerticalLabeling5��5�      $
��Left=�67   $��31��6R   $��
11,174,0,0q�6^   $
 Wrap=�6r   $�� E��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $ -1.569,1.613&�6�    . $��1��6  ���	#FFBFF1E66  �� 5�      -   5        $
 txtBoxVerticalLabeling6��5�      $
��Left=�67   $��31��6R   $��
11,202,0,0q�6^   $
 Wrap=�6r   $�� F��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $ 0.155,1.855&�6�    . $��1��6  ���	#FFBFF1E66  �� 5�      -   5        $
 txtBoxVerticalLabeling7��5�      $
��Left=�67   $��31��6R   $��
11,233,0,0q�6^   $
 Wrap=�6r   $�� G��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $��1��6�   ���	#FFBFF1E66�   �� 5�      -   5        $
 txtBoxVerticalLabeling8��5�      $
��Left=�67   $��31��6R   $��
11,263,0,0q�6^   $
 Wrap=�6r   $�� H��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $��1��6�   ���	#FFBFF1E66�   �� 5�      -    5        $
 txtBoxVerticalLabeling9��5�      $
��Left=�67   $��31��6R   $��
11,294,0,0q�6^   $
 Wrap=�6r   $�� I��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $ 0.138,0.516&�6�   $��1��6  ���	#FFBFF1E66  �� 5�      -!   5        $
 txtBoxVerticalLabeling10��5�      $
��Left=�68   $��31��6S   $��
11,324,0,0q�6_   $
 Wrap=�6s   $�� J��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�    . $��1��6�   ���	#FFBFF1E66�   �� 5�      -"   5        $
 txtBoxVerticalLabeling1_2��5�      $
��Left=�69   $��30��6T   $��
371,57,0,0q�6`   $
 Wrap=�6t   $�� A��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $ 12.897,0.417&�6�   $��1��6�    . ���	#FFBFF1E66   �� 5�      -#   5        $
 txtBoxVerticalLabeling2_2��5�      $
��Left=�69   $��28��6T   $��
371,85,0,0q�6`   $
 Wrap=�6t   $�� B��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�    . ���	#FFBFF1E66�   �� 5�      -$   5        $
 txtBoxVerticalLabeling3_2��5�      $
��Left=�69   $��31��6T   $��371,112,0,0q�6`   $
 Wrap=�6u   $�� C��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�    . ���	#FFBFF1E66�   �� 5�      -%   5        $
 txtBoxVerticalLabeling4_2��5�      $
��Left=�69   $��31��6T   $��371,143,0,0q�6`   $
 Wrap=�6u   $�� D��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�    . ���	#FFBFF1E66�   �� 5�      -&   5        $
 txtBoxVerticalLabeling5_2��5�      $
��Left=�69   $��31��6T   $��371,174,0,0q�6`   $
 Wrap=�6u   $�� E��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $ -1.569,1.613&�6�   $��1��6�    . ���	#FFBFF1E66!  �� 5�      -'   5        $
 txtBoxVerticalLabeling6_2��5�      $
��Left=�69   $��31��6T   $��371,206,0,0q�6`   $
 Wrap=�6u   $�� F��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $ 0.155,1.855&�6�   $��1��6�    . ���	#FFBFF1E66   �� 5�      -(   5        $
 txtBoxVerticalLabeling7_2��5�      $
��Left=�69   $��31��6T   $��371,233,0,0q�6`   $
 Wrap=�6u   $�� G��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�    . ���	#FFBFF1E66�   �� 5�      -)   5        $
 txtBoxVerticalLabeling8_2��5�      $
��Left=�69   $��31��6T   $��371,263,0,0q�6`   $
 Wrap=�6u   $�� H��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�    . ���	#FFBFF1E66�   �� 5�      -*   5        $
 txtBoxVerticalLabeling9_2��5�      $
��Left=�69   $��31��6T   $��371,294,0,0q�6`   $
 Wrap=�6u   $�� I��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�   $ 0.121,0.629&�6�    . ���	#FFBFF1E66   �� 5�      -+   5        $ 
 txtBoxVerticalLabeling10_2��5�      $
��Left=�6:   $��31��6U   $��371,324,0,0q�6a   $
 Wrap=�6v   $�� J��6�   $	��Top=�6�   $��29��6�   $��14.667(�6�   $
��Bold"�6�   $��1��6�    . ���	#FFBFF1E66�   �� 5�      -,   5        $	 lblColBattleship��5�      $
��Col:��6b   $
��Left=�6q   $��227,319,0,0q�6�   $	��Top=�6�   $��16(�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6�    6.   �� $ textBoxColBattleship��6�   �� 5�      --   5        $	 lblRowBattleship��5�      $
��Row:��6b   $
��Left=�6q   $��227,291,0,0q�6�   $	��Top=�6�   $��16(�6�   $ 
0.455,0.44&�6�   ���	#FFE4B20A$
��Bold"�6  $y�Hidden=�6   6.   �� $ textBoxRowBattleship��6  �� 5�      -.   5        $
 textBoxColBattleship��5�      $
��Left=�64   $��23��6O   $��283,325,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $��50��6�   
����������	#FF2B281C$��18(�6�   $��Center=�6�   $y�Hidden=�6  �� 5�      -/   5        $
 textBoxRowBattleship��5�      $
��Left=�64   $��26��6O   $��283,294,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $��50��6�   $ 
0.46,0.565&�6�   ���	#FFFBFBFB���	#FF2B281C$��18(�6�   $y�Hidden=�6  �� 5�      -0   5        $ buttonOKBattleship��5�      $��OK��61   $
��Left=�6>   $��356,300,0,0q�6Y   $	��Top=�6n   $��40��6�   $��16(�6�   $��36��6�   $ 0.425,0.139&�6�   ���	#FF54B49E$y�Hidden=�6  �� 5�      -1   5         ��Name$ groupboxBattleship��5�      $��61,72,362,601q�5�      $y�Visible=�6$   $��0q�6P   ��69   Z� .��5�      � $��Right=�5�      $	��119��5�      $��-44,-15,-12,-39q�5�      $	��Top=�5�      $	��117��5�      5�      5�      	� 5�      -2   5        $% radioButtonHorizontalBattleship��5�      $��
Horizontal��6C   $
��Left=�6X   $��265,350,0,0q�6s   $	��Top=�6�   $��14(�6�   $ 0.53,-0.067&�6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   	� 5�      -3   5        $# radioButtonVerticalBattleship��5�      $��Vertical��6A   $
��Left=�6T   $��265,370,0,0q�6o   $	��Top=�6�   $��14(�6�   $��86��6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   �� 5�      -4   5        $
 textBoxColSubmarine��5�      $
��Left=�63   $��23��6N   $��283,430,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��50��6�   
����������	#FF2B281C$��18(�6�   $��Center=�6�   $y�Hidden=�6   �� 5�      -5   5        $
 textBoxRowSubmarine��5�      $
��Left=�63   $��26��6N   $��283,399,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��50��6�   
����������	#FF2B281C$��18(�6�   $y�Hidden=�6�   �� 5�      -6   5        $	 lblColSubmarine��5�      $
��Col:��6`   $
��Left=�6o   $��227,423,0,0q�6�   $	��Top=�6�   $��16(�6�   $ 
0.696,3.92&�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6   6-   �� $ textBoxColSubmarine��6  �� 5�      -7   5        $	 lblRowSubmarine��5�      $
��Row:��6`   $
��Left=�6o   $��227,396,0,0q�6�   $	��Top=�6�   $��16(�6�   $ 
0.606,0.08&�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6   6-   �� $ textBoxRowSubmarine��6  �� 5�      -8   5        $ buttonOKSubmarine��5�      $��OK��60   $
��Left=�6=   $��356,405,0,0q�6X   $	��Top=�6m   $��40��6�   $��16(�6�   $��36��6�   $ 	2.4,2.889&�6�   ���	#FF54B49E$y�Hidden=�6  	� 5�      -9   5        $$ radioButtonHorizontalSubmarine��5�      $��
Horizontal��6B   $
��Left=�6W   $��265,455,0,0q�6r   $	��Top=�6�   $��14(�6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   	� 5�      -:   5        $" radioButtonVerticalSubmarine��5�      $��Vertical��6@   $
��Left=�6S   $��265,475,0,0q�6n   $	��Top=�6�   $��14(�6�   $��86��6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   �� 5�      -;   5        $	 lblColCruiser��5�      $
��Col:��6\   $
��Left=�6k   $��227,527,0,0q�6�   $	��Top=�6�   $��16(�6�   $ 0.393,4&�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6
   6+   �� $ textBoxRowCruiser��6
  �� 5�      -<   5        $	 lblRowCruiser��5�      $
��Row:��6\   $
��Left=�6k   $��227,496,0,0q�6�   $	��Top=�6�   $��16(�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6�    6+   �� $ textBoxColCruiser��6�   �� 5�      -=   5        $
 textBoxColCruiser��5�      $
��Left=�61   $��23��6L   $��283,529,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $��50��6�   
����������	#FF2B281C$��18(�6�   $��Center=�6�   $ 
0.58,0.913&�6�   $y�Hidden=�6!  �� 5�      ->   5        $
 textBoxRowCruiser��5�      $
��Left=�61   $��26��6L   $��283,498,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $��50��6�   
����������	#FF2B281C$��18(�6�   $y�Hidden=�6�   �� 5�      -?   5        $ buttonOKCruiser��5�      $��OK��6.   $
��Left=�6;   $��356,501,0,0q�6V   $	��Top=�6k   $��40��6�   $��16(�6�   $��36��6�   $ 0.475,0.278&�6�   ���	#FF54B49E$y�Hidden=�6  	� 5�      -@   5        $" radioButtonHorizontalCruiser��5�      $��
Horizontal��6@   $
��Left=�6U   $��265,555,0,0q�6p   $	��Top=�6�   $��14(�6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   	� 5�      -A   5        $  radioButtonVerticalCruiser��5�      $��Vertical��6>   $
��Left=�6Q   $��265,575,0,0q�6l   $	��Top=�6�   $��14(�6�   $��86��6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   �� 5�      -B   5        $	 lblColDestroyer��5�      $
��Col:��6`   $
��Left=�6o   $��227,632,0,0q�6�   $	��Top=�6�   $��16(�6�   $ 
0.696,3.92&�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6   6-   �� $ textBoxRowDestroyer��6  �� 5�      -C   5        $	 lblRowDestroyer��5�      $
��Row:��6`   $
��Left=�6o   $��227,601,0,0q�6�   $	��Top=�6�   $��16(�6�   $ 0.545,2&�6�   ���	#FFE4B20A$
��Bold"�6�   $y�Hidden=�6   6-   �� $ textBoxColDestroyer��6  �� 5�      -D   5        $
 textBoxColDestroyer��5�      $
��Left=�63   $��23��6N   $��283,638,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��50��6�   
����������	#FF2B281C$��18(�6�   $y�Hidden=�6�   �� 5�      -E   5        $
 textBoxRowDestroyer��5�      $
��Left=�63   $��26��6N   $��283,607,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��50��6�   $ 	0.5,1.174&�6�   
����������	#FF2B281C$��18(�6�   $��Center=�6   $y�Hidden=�6"  �� 5�      -F   5        $ buttonOKDestroyer��5�      $��OK��60   $
��Left=�6=   $��356,613,0,0q�6X   $	��Top=�6m   $��40��6�   $��16(�6�   $��36��6�   ���	#FF54B49E$y�Hidden=�6�   	� 5�      -G   5        $$ radioButtonHorizontalDestroyer��5�      $��
Horizontal��6B   $
��Left=�6W   $��265,663,0,0q�6r   $	��Top=�6�   $��14(�6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   	� 5�      -H   5        $" radioButtonVerticalDestroyer��5�      $��Vertical��6@   $
��Left=�6S   $��265,683,0,0q�6n   $	��Top=�6�   $��14(�6�   $��86��6�   ���	#FFE4B20A$��Medium"�6�   $y�Hidden=�6�   �� 5�      -I   5        $
 textBoxPlayerCol��5�      $��1��60   $
��Left=�6@   $��23��6[   $��554,427,0,0q�6g   $
 Wrap=�6|   $	��Top=�6�   $��66��6�   
�������$y�Hidden=�6�   $��18(�6�   �� 5�      -J   5        $
 textBoxPlayerRow��5�      $��1��60   $
��Left=�6@   $��23��6[   $��554,392,0,0q�6g   $
 Wrap=�6|   $	��Top=�6�   $��66��6�   
�������$y�Hidden=�6�   $��18(�6�   �� 5�      -K   5        $	 labelPlayerCol��5�      $��Enter the Column:��6,   $��1��6H   $
��Left=�6X   $��371,419,0,0q�6s   $	��Top=�6�   $��35��6�   $	��166��6�   ���	#FFE4B20A$��18(�6�   $
��Bold"�6�   $y�Hidden=�6  ��6�   Z� 6  �� 5�      -L   5        $	 labelPlayerRow��5�      $��Enter the Row:��6,   $��1��6E   $
��Left=�6U   $��371,383,0,0q�6p   $	��Top=�6�   $��32��6�   $	��135��6�   ���	#FFE4B20A$��18(�6�   $
��Bold"�6�   $y�Hidden=�6  ��6�   Z� 6  �� 5�      -M   5        $	 labelOutOfRange��5�      $*��$The range for row and column is 1-10��6-   $
��Left=�6\   $��	0,373,0,0q�6w   $	��Top=�6�   $��39��6�   $	��300��6�   $��16(�6�   ���	#FFFFBAA0$y�Hidden=�6�   $��1��6�   $��	ExtraBold"�6  $��	Yu Gothic)�63  ��6  Z� 63  �� 5�      -N   5        $ buttonOKPlay��5�      $��OK��6+   $��1��68   $
��Left=�6H   $��638,406,0,0q�6c   $	��Top=�6x   $��46��6�   $��32��6�   $��16(�6�   $ 0.217,-0.437&�6�   ���	#FF09745C$y�Hidden=�6  |�.  6   �� 5�      -O   5        $	 labelPlayerWins��5�      $��'s Wins:��6-   $
��Left=�6@   $��
31,105,0,0q�6[   $	��Top=�6o   $	��176��6�   $��39��6�   $��24(�6�   $
��Bold"�6�   ���	#FFFFC500$y�Hidden=�6�   �� 5�      -P   5        $	 labelPlayerLosses��5�      $��Computer's Wins:��6/   $
��Left=�6J   $��
31,180,0,0q�6e   $	��Top=�6y   $	��211��6�   $��48��6�   $��24(�6�   $
��Bold"�6�   ���	#FFFFC500$y�Hidden=�6�   �� 5�      -Q   5        $
 txtPlayerWinPoints��5�      $��0��62   $
��Left=�6;   $��262,112,0,0q�6V   $	��Top=�6k   $	��134��6�   $��32��6�   $��18.667(�6�   $
��Bold"�6�    . $��Center=�6�   ���	#FF09745C���	#FF09745C$y�Hidden=�6"  �� 5�      -R   5        $
 txtPlayerLossPoints��5�      $��0��63   $
��Left=�6<   $��265,188,0,0q�6W   $	��Top=�6l   $	��134��6�   $��33��6�   $��18.667(�6�   $
��Bold"�6�    . $��Center=�6�   ���	#FF09745C���	#FF09745C$y�Hidden=�6$  �� 5�      -S   5        $ buttonReset��5�      $��RESET��6*   $
��Left=�6:   $��	638,0,0,0q�6U   $	��Top=�6h   $	��118��6�   $��28��6�   ���	#FF2B2614���	#FF54B49E$��1��6�   $��SemiBold"�6�   $y�Hidden=�6  �� 5�      -T   5        $	 lblHelp��5�      $9��3Click on the ship to 
choose the first
coordinate:��6%   $
��Left=�6o   $��141,149,0,0q�6�   $	��Top=�6�   $	��185��6�   
�������$��Verdana)�6�   $��56��6�   $��12(�6�   ��6  Z� �� 5�      $	��134��6   $��38��6    $��1��6,   $��40,380,582,326q�6<   $��Ships left:��6T   ���	#FFFFC500$��28(�6�   �� 5�      -U   5        $	 userShipsLeftLabel��5�      $	��134��60   $��38��6<   $��1��6H   $��179,383,443,323q�6X   ���	#FFFFC500$��28(�6�   �� 5�      $	��134��6   $��38��6    $��1��6,   $��416,383,206,323q�6<   $��Ships left:��6U   ���	#FFFFC500$��28(�6�   �� 5�      -V   5        $	 enemyShipsLeftLabel��5�      $	��134��61   $��38��6=   $��1��6I   $��555,386,67,320q�6Y   ���	#FFFFC500$��28(�6�   $ 0.5,0.5&�6�   5�      5�      5�      