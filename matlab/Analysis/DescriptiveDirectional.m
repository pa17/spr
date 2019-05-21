function DescriptiveDirectional

close all
clear
clc

figure('Renderer', 'painters', 'Position', [5 5 800 300]);


m = csvread('DataClean.csv', 1);
t = table(m(:,3), m(:,4), m(:,5),'VariableNames',{'S1','S2','S3'});

s1c = sum(m(:,3) == 1) / 20
s1f = sum(m(:,3) == 0) / 20

s2c = sum(m(:,4) == 1) / 20
s2f = sum(m(:,4) == 0) / 20

s3c = sum(m(:,5) == 1) / 20
s3f = sum(m(:,5) == 0) / 20

c = categorical({'S1','S2','S3'});
bar(c, [s1c s1f; s2c s2f; s3c s3f], 'stacked')
legend('Correct', 'Wrong')
ylabel('Directional Responses Percentage')

end