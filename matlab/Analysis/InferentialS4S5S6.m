function InferentialS4S5S6

close all
clear
clc

m = csvread('DataClean.csv', 1);
% Select S4, S5, S6
m = m(:,9:11);

% Comparing S4, S5, S6 therefore friedman
[P, ANOVATAB, STATS] = friedman(m);

% Significant, therefore post-hoc Dunn
[COMPARISON, MEANS, H, GNAMES] = multcompare(STATS,'ctype','dunn-sidak')

