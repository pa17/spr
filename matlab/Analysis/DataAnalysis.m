function DataAnalysis

close all
clear
clc

m = csvread('DataClean.csv', 1);

% Directional or Time responses?
DIRECTIONAL = 0;
TIME = 1;

% Scenario
SCENARIO = 1;

if DIRECTIONAL
    COLUMN = SCENARIO + 1;
elseif TIME
    COLUMN = SCENARIO + 5;
end
    
% desmean = mean(m(:,COLUMN));
% desmedian = median(m(:,COLUMN));
% desstddev = std(m(:,COLUMN));
% histogram(m(:,COLUMN));
% histfit(m(:,COLUMN));
% 
% title('Scenario: ' + COLUMN);

%% TIME

figure('Renderer', 'painters', 'Position', [5 5 800 300]);

% subplot(1,2,1)
% histogram(m(:,2))
% xlabel('Distance from platform centre (m)')
% 
% subplot(1,2,2)
% scatter(m(:,2), m(:,9), 'g');
% prms = polyfit(m(:,2),m(:,9),1);
% hold on
% plot(m(:,2), polyval(prms, m(:,2)), 'g');
% 
% scatter(m(:,2), m(:,10), 'r');
% prms = polyfit(m(:,2),m(:,10),1);
% plot(m(:,2), polyval(prms, m(:,2)), 'r');
% 
% scatter(m(:,2), m(:,11), 'b');
% prms = polyfit(m(:,2),m(:,11),1);
% plot(m(:,2), polyval(prms, m(:,2)), 'b');
% 
% legend('S4', 'S4 Trend', 'S5', 'S5 Trend', 'S6', 'S6 Trend', 'Location','southeast')
% xlabel('Distance from platform centre (m)')
% ylabel('Response time (s)')

% Boxplots
figure('Renderer', 'painters', 'Position', [5 5 800 300]);
boxplot(m(:,(6:11)), 'labels', {'S1: Control', 'S2: Audio Illusion', 'S3: Audio + Light Illusion', 'S4: Control 2', 'S5: Block Obstruction', 'S6: Curtain Obstruction'})
ylabel('Response Time (s)');
% 
% % Histograms
% figure('Renderer', 'painters', 'Position', [5 5 800 300]);
% subplot(2,3,1)
% histogram(m(:,6));
% histfit(m(:,6));
% title('S1')
% 
% subplot(2,3,2)
% histogram(m(:,7));
% histfit(m(:,7));
% title('S2')
% 
% subplot(2,3,3)
% histogram(m(:,8));
% histfit(m(:,8));
% title('S3')
% 
% subplot(2,3,4)
% histogram(m(:,9));
% histfit(m(:,9));
% title('S4')
% 
% subplot(2,3,5)
% histogram(m(:,10));
% histfit(m(:,10));
% title('S5')
% 
% subplot(2,3,6)
% histogram(m(:,11));
% histfit(m(:,11));
% title('S6')

end