function InferentialS1S2S3

close all
clear
clc

m = csvread('DataClean.csv', 1);
t = table(m(:,6), m(:,7), m(:,8),'VariableNames',{'S1','S2','S3'});

% Create repeated measures model
rm = fitrm(t, 'S1, S2, S3~1');
[TBL]=ranova(rm);

% Significant Difference --> individual t-tests between groups.
[H, P, CI, STATS] = ttest(m(:,6),m(:,7));
display("S1 vs. S2: " + P);
[H, P, CI, STATS] = ttest(m(:,6),m(:,8))
display("S1 vs. S3: " + P)
[H, P, CI, STATS] = ttest(m(:,7),m(:,8));
display("S2 vs. S3: " + P);




