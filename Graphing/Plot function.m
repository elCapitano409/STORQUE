a = arduino;
line1 = line(nan, nan, 'color', 'red');
i = 0;
while i
    pot = readWeight(a,'A0');
    pause(0.5) ;%wait 0.5 seconds before reading info again
    
    x1 = get(line1, 'xData');
    y1 = get(line1, 'yData');
    
    x1 = [x1 i];
    y1 = [y1 pot];
    
    set(line1, 'xData', x1, 'yData', y1);
    
    i=i+1
    pause(1)
end
